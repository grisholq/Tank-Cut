using Leopotam.Ecs;
using UnityEngine;

public class PatrolCurrentPointUpdateSystem : IEcsRunSystem
{
    private readonly EcsFilter<PatrolPoints, PatrolCurrentPoint, PatrolNextPoint, PatrolPointReachedEvent> _reachedPointsFilter;

    public void Run()
    {
        if (_reachedPointsFilter.IsEmpty()) return;

        foreach (var i in _reachedPointsFilter)
        {
            ref var currentPoint = ref _reachedPointsFilter.Get2(i);
            ref var nextPoint = ref _reachedPointsFilter.Get3(i);

            currentPoint.Index = nextPoint.Index;
            currentPoint.Position = nextPoint.Position;
        }
    }
}