using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class LevelRestartSystem : IEcsRunSystem
{
    private readonly EcsFilter<LevelRestartEvent> _restartEventFilter;

    public void Run()
    {
        if (_restartEventFilter.IsEmpty()) return;

        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current);

        _restartEventFilter.GetEntity(0).Destroy();
    }
}