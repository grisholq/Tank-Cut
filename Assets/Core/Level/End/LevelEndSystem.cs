using UnityEngine;
using Leopotam.Ecs;

public class LevelEndSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<LevelWonEvent> _wonEventsFilter;
    private readonly EcsFilter<LevelLostEvent> _lostEventsFilter;

    public void Run()
    {
        if (_wonEventsFilter.IsEmpty() && _lostEventsFilter.IsEmpty()) return;

        _world.NewEntity().Get<LevelEndState>();
    }
}