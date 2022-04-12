using Leopotam.Ecs;
using UnityEngine;

public class LevelLoseScreenSystem : IEcsRunSystem
{
    private readonly EcsFilter<LoseScreenComponent> _loseScreenFilter;
    private readonly EcsFilter<LevelLostEvent> _loseEventFilter;

    public void Run()
    {
        if (_loseEventFilter.IsEmpty()) return;

        var loseScreen = _loseScreenFilter.Get1(0);
        loseScreen.Screen.SetActive(true);
    }
}