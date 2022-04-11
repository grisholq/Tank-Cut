using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;
using UnityEngine.Events;

public class ConvertToEntityInstantly : ConvertToEntity
{
    [SerializeField] private UnityEvent<EcsEntity> EntityInizialized;

    private void Awake()
    {
        AddEntity(this.gameObject);
    }

    private void AddEntity(GameObject gameObject)
    {
        EcsEntity entity = WorldHandler.GetWorld().NewEntity();

        foreach (var component in gameObject.GetComponents<Component>())
        {
            if (component is IConvertToEntity entityComponent)
            {
                entityComponent.Convert(entity);
                Destroy(component);
            }
        }

        EntityInizialized.Invoke(entity);

        Destroy(this);
    }
}
