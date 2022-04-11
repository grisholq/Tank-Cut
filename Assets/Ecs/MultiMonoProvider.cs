using UnityEngine;
using System.Collections.Generic;
using Voody.UniLeo;
using Leopotam.Ecs;
using System.Linq;
using System;
using Unity.Collections;
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
#endif

namespace DCFA
{
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    sealed class EcsComponentColorAttribute : Attribute
    {
        public readonly Color color;
        public EcsComponentColorAttribute(float r, float g, float b)
        {
            color = new Color(r, g, b);
        }
    }
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    sealed class EcsLinkComponentAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    sealed class EcsTagComponentAttribute : Attribute { }

    [RequireComponent(typeof(ConvertToEntity))]
    public class MultiMonoProvider : BaseMonoProvider, IConvertToEntity
    {
#pragma warning disable IDE0044
        [SerializeReference]
        private object[] _tags = new object[0];
        [SerializeReference]
        private object[] _components = new object[0];
#pragma warning restore IDE0044
#pragma warning disable IDE0051
        private void ConvertHelper<T>(EcsEntity entity, ref T component) where T : struct
#pragma warning restore IDE0051
        {
            entity.Replace(component);
        }
        private static MethodInfo convertHelper = typeof(MultiMonoProvider).GetMethod("ConvertHelper", BindingFlags.Instance | BindingFlags.NonPublic);
        void IConvertToEntity.Convert(EcsEntity entity)
        {
            ConvertArray(_tags, entity);
            ConvertArray(_components, entity);
        }

        private void ConvertArray(object[] array, object entity)
        {
            foreach (var component in array)
            {
                MethodInfo helperConvertGeneric = convertHelper.MakeGenericMethod(component.GetType());
                helperConvertGeneric.Invoke(this, new object[] { entity, component });
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MultiMonoProvider))]
    public class MultiMonoProviderEditor : Editor
    {
        private ReorderableList reorderableListComponents;
        private ReorderableList reorderableListTags;
        private static readonly float spacing = 5f;
        private static readonly float padding = 6f;

        private readonly List<Type> structTypeCache = new List<Type>();
        private object[] targetComponents;
        private void UpdateTargetComponents()
        {
            targetComponents = (object[])target.GetType().GetField("_components", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);
        }
        private void Init()
        {
            reorderableListTags = new ReorderableList(serializedObject, serializedObject.FindProperty("_tags"), true, true, false, false)
            {
                drawElementCallback = OnDrawElementTags,
                elementHeightCallback = OnElementHeightTags,
                drawHeaderCallback = OnDrawHeaderTags
            };
            reorderableListComponents = new ReorderableList(serializedObject, serializedObject.FindProperty("_components"), true, true, false, false)
            {
                drawElementCallback = OnDrawElementComponents,
                elementHeightCallback = OnElementHeightComponents,
                drawHeaderCallback = OnDrawHeaderComponents
            };

            structTypeCache.Clear();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsValueType)
                    {
                        structTypeCache.Add(type);
                    }
                }
            }
        }

        private MonoScript selectedScript = null;

        public override void OnInspectorGUI()
        {
            UpdateTargetComponents();
            if (reorderableListComponents == null)
                Init();

            if (reorderableListComponents.serializedProperty.arraySize > 0 && 
                string.IsNullOrEmpty(reorderableListComponents.serializedProperty.GetArrayElementAtIndex(0).managedReferenceFullTypename))
            {
                DrawErrorMessage();
                return;
            }

            EditorGUI.BeginChangeCheck();
            if (reorderableListTags.serializedProperty.arraySize > 0)
            {
                reorderableListTags.DoLayoutList();
                GUILayout.Space(-EditorGUIUtility.singleLineHeight + 8f);
            }
            reorderableListComponents.DoLayoutList();
            if (EditorGUI.EndChangeCheck()) serializedObject.ApplyModifiedProperties();

            Rect addBlockRect = GUILayoutUtility.GetLastRect();
            addBlockRect.yMin = addBlockRect.yMax - EditorGUIUtility.singleLineHeight;
            DrawAddBlock(addBlockRect);
        }

        private void DrawErrorMessage()
        {
            EditorGUILayout.HelpBox("Error.", MessageType.Error);
        }

        private void DrawAddBlock(Rect position)
        {
            float labelwidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 26f;
            if (selectedScript == null)
                selectedScript = (MonoScript)EditorGUI.ObjectField(position, "Add", selectedScript, typeof(MonoScript), false);

            if (selectedScript != null)
            {
                string[] typeFullNames = SimpleCodeParser.GetAllTypeFullNames(selectedScript.text);
                if (typeFullNames.Length > 0)
                {
                    if (typeFullNames.Length == 1)
                    {
                        AddComponent(typeFullNames[0]);
                        selectedScript = null;
                    }
                    else
                    {
                        Rect rect1 = position;
                        rect1.width *= 0.4f;
                        Rect rect2 = position;
                        rect2.width = position.width - rect1.width;
                        rect2.x = rect1.xMax;
                        selectedScript = (MonoScript)EditorGUI.ObjectField(rect1, "Add", selectedScript, typeof(MonoScript), false);
                        int selectedStructIndex = EditorGUI.Popup(rect2, -1, typeFullNames);
                        rect2.xMin += 5;
                        GUI.Label(rect2, "Select component ...");
                        if (selectedStructIndex >= 0)
                        {
                            AddComponent(typeFullNames[selectedStructIndex]);
                            selectedScript = null;
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("this MonoScript does not contain struct");
                    selectedScript = null;
                }
            }
            EditorGUIUtility.labelWidth = labelwidth;
        }

        #region ReorderableListCallbacks
        private void OnDrawHeaderTags(Rect rect)
        {
            GUI.Label(rect, "Tags");
        }
        private void OnDrawHeaderComponents(Rect rect)
        {
            GUI.Label(rect, "Components");
        }
        private float OnElementHeightTags(int index)
        {
            return OnElementHeight(index, reorderableListTags);
        }
        private float OnElementHeightComponents(int index)
        {
            return OnElementHeight(index, reorderableListComponents);
        }
        private float OnElementHeight(int index, ReorderableList list)
        {
            SerializedProperty componentElem = list.serializedProperty.GetArrayElementAtIndex(index);
            float blockHeight = EditorGUI.GetPropertyHeight(componentElem);

            if (EditorGUIUtility.singleLineHeight == blockHeight)
                return EditorGUIUtility.singleLineHeight + spacing;

            return blockHeight + spacing + padding * 2f;
        }

        private Type GetType(string fullname)
        {
            foreach (var item in structTypeCache)
            {
                if (item.FullName == fullname)
                    return item;
            }

            return null;
        }
        private bool TryGetAttribute<T>(Type type, out T attribute) where T : Attribute
        {
            if (type == null)
            {
                attribute = null;
                return false;
            }
            attribute = type.GetCustomAttribute<T>();
            return attribute != null;
        }
        private bool CheckAttribute<T>(Type type) where T : Attribute
        {
            return !(type.GetCustomAttribute<T>() == null);
        }

        private void OnDrawElementComponents(Rect rect, int index, bool isActive, bool isFocused)
        {
            OnDrawElement(rect, reorderableListComponents, index, isActive, isFocused);
        }
        private void OnDrawElementTags(Rect rect, int index, bool isActive, bool isFocused)
        {
            OnDrawElement(rect, reorderableListTags, index, isActive, isFocused);
        }

        private void OnDrawElement(Rect rect, ReorderableList list, int index, bool isActive, bool isFocused)
        {
            Rect boxPosition = rect;
            boxPosition.xMin -= padding + 15f;
            boxPosition.xMax += padding;
            boxPosition.height = EditorGUIUtility.singleLineHeight + 2f;

            Rect position = rect;
            SerializedProperty componentElem = list.serializedProperty.GetArrayElementAtIndex(index);

            GUIContent label = new GUIContent
            {
                text = componentElem.managedReferenceFullTypename.Split(' ').Last()
            };

            Type componentType = GetType(label.text);

            if (GUI.skin.name != "DarkSkin")
                GUI.color *= 1.05f;
            GUI.Box(boxPosition, "", EditorStyles.toolbarButton);

            if (TryGetAttribute(componentType, out EcsComponentColorAttribute attribute))
            {
                Color c = attribute.color;
                c.a = 0.5f;
                GUI.color = c;

                GUI.Box(boxPosition, "▌", EditorStyles.whiteLabel);
            }

            GUI.color = Color.white;
            EditorGUI.PropertyField(position, componentElem, label, true);

            GUI.color = new Color(1f, 0.35f, 0.48f);
            Rect buttonPosition = boxPosition;
            buttonPosition.xMin = buttonPosition.xMax - buttonPosition.height * 0.8f;
            buttonPosition.x += buttonPosition.width * 0.3f;
            

            DrawDeleteButton(buttonPosition, list, index);


            GUI.color = Color.white;
        }

        private void DrawDeleteButton(Rect position, ReorderableList list, int itemIndex)
        {
            GUIStyle style = new GUIStyle(EditorStyles.miniButton)
            {
                padding = new RectOffset(0, 0, 0, 0)
            };
            if (GUI.Button(position, "x", style))
            {
                list.serializedProperty.DeleteArrayElementAtIndex(itemIndex);
            }
        }

        private void AutoFillLinkComponent(int componentIndex, Type componentType)
        {
            foreach (var field in componentType.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                if (!field.FieldType.IsSubclassOf(typeof(Component)) ||
                    !field.GetValue(targetComponents[componentIndex]).Equals(null))
                    continue;

                field.SetValue(targetComponents[componentIndex], ((Component)target).GetComponent(field.FieldType));
            }

            EditorUtility.SetDirty(target);
            serializedObject.ApplyModifiedProperties();
        }
        #endregion

        private void AddComponent(string typeFullName)
        {
            SerializedProperty componentsArrayPropComponents = serializedObject.FindProperty("_components");
            SerializedProperty componentsArrayPropTags = serializedObject.FindProperty("_tags");
            
            foreach (var type in structTypeCache)
            {
                if (type.FullName == typeFullName)
                {
                    SerializedProperty arrayprop = CheckAttribute<EcsTagComponentAttribute>(type) ? componentsArrayPropTags : componentsArrayPropComponents;
                    int index = arrayprop.arraySize;
                    arrayprop.InsertArrayElementAtIndex(index);
                    SerializedProperty componentElem = arrayprop.GetArrayElementAtIndex(index);
                    componentElem.managedReferenceValue = Activator.CreateInstance(type);
                    serializedObject.ApplyModifiedProperties();

                    if (TryGetAttribute(type, out EcsLinkComponentAttribute _))
                    {
                        UpdateTargetComponents();
                        AutoFillLinkComponent(index, type);
                    }

                    return;
                }
            }
            Debug.LogError("Failed to add component");
        }


        private static class SimpleCodeParser
        {
            const string STRUCT = "struct";
            const string NAMESPACE = "namespace";

            public static string[] GetAllTypeFullNames(string code)
            {
                code = CleanCode(code);

                List<string> result = new List<string>();
                List<string> chain = new List<string>();

                string[] splitcode = code.Split(new char[] { '{' }, System.StringSplitOptions.RemoveEmptyEntries);
                int depth = 0;

                for (int i = 0; i < splitcode.Length; i++)
                {
                    depth -= splitcode[i].Count(o => o == '}');

                    int jMax = chain.Count - depth;
                    for (int j = 0; j < jMax; j++)
                    {
                        chain.RemoveAt(chain.Count - 1);
                    }

                    int indexof;
                    indexof = splitcode[i].IndexOf(NAMESPACE);
                    if (indexof >= 0)
                    {
                        int start = indexof + NAMESPACE.Length;
                        chain.Add(splitcode[i].Substring(start).Replace("{", "").Replace("}", ""));
                    }


                    indexof = splitcode[i].IndexOf(STRUCT);
                    if (indexof >= 0)
                    {
                        int start = indexof + STRUCT.Length;
                        string name = splitcode[i].Substring(start).Replace("{", "").Replace("}", "");
                        if (name.Contains(':'))
                            name = name.Substring(0, name.IndexOf(":"));
                        chain.Add(name);

                        result.Add(string.Join(".", chain));
                    }

                    depth++;
                }

                return result.ToArray();
            }

            private static string CleanCode(string code)
            {
                while (code.Contains("/*"))
                {
                    int start = code.IndexOf("/*");
                    code = code.Remove(start, code.IndexOf("*/") - start + 2);
                }
                code = code.Replace(" ", "");
                code = code.Replace("\n", "");
                code = code.Replace("\r", "");
                return code;
            }
        }
    } 
#endif
}