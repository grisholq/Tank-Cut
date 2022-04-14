using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class LevelNextSystem : IEcsRunSystem
{
    private readonly EcsFilter<NextLevelEvent> _nextLevelFilter;

    public void Run()
    {
        if (_nextLevelFilter.IsEmpty()) return;

        LevelPassData.NextLevel();
        int currentLevel = LevelPassData.GetCurrentLevelIndex();
        SceneManager.LoadScene(currentLevel);
    }
}