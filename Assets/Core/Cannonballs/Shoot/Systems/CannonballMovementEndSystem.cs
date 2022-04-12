using Leopotam.Ecs;
using UnityEngine;

public class CannonballMovementEndSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<CannonballTag, SplineMovementEnded> _endedCannonballsFilter;

    public void Run()
    {
        if (_endedCannonballsFilter.IsEmpty()) return;

        foreach (var i in _endedCannonballsFilter)
        {
            _world.NewEntity().Get<CannonballMovementEndedEvent>();
        }
    }
}