using UnityEngine;
using Leopotam.Ecs;

public class LevelWinScreenSystem : IEcsRunSystem
{
    private readonly EcsFilter<WinScreenComponent> _winScreenFilter;
    private readonly EcsFilter<LevelWonEvent> _winEventFilter;

    public void Run()
    {
        if (_winEventFilter.IsEmpty()) return;

        var winScreen = _winScreenFilter.Get1(0);
        winScreen.Screen.SetActive(true);
    }
}