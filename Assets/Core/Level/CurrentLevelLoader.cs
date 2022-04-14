using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevelLoader : MonoBehaviour
{
    [SerializeField] private bool _reset;

    private void Start()
    {
        if(_reset)
        {
            LevelPassData.Reset();
        }
   
        int currentLevel = LevelPassData.GetCurrentLevelIndex();
        SceneManager.LoadScene(currentLevel);
    }
}