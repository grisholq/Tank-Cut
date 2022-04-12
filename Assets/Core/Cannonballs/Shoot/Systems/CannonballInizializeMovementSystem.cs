using Leopotam.Ecs;
using UnityEngine;

public class CannonballInizializeMovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineMovementStarted> _startedCannonballsFilter;

    public void Run()
    {
        foreach (var i in _startedCannonballsFilter)
        {
            ref var movePercent = ref _startedCannonballsFilter.GetEntity(i).Get<SplineMovePercent>();
            movePercent.Percent = 0;
        }
    }
}