using Leopotam.Ecs;
using UnityEngine;

public class PatrolNextPointUpdateSystem : IEcsRunSystem
{
    private readonly EcsFilter<PatrolPoints, PatrolCurrentPoint, PatrolNextPoint, PatrolPointReachedEvent> _reachedPointsFilter;

    public void Run()
    {
        if (_reachedPointsFilter.IsEmpty()) return;

        foreach (var i in _reachedPointsFilter)
        {
            var points = _reachedPointsFilter.Get1(i).Points;
            ref var nextPoint = ref _reachedPointsFilter.Get3(i);

            int pointsCount = points.Length;

            if(pointsCount <= (nextPoint.Index + 1))
            {
                nextPoint.Index = 0;
                nextPoint.Position = points[0];
            }
            else
            {
                nextPoint.Index++;
                nextPoint.Position = points[nextPoint.Index];
            }
        }
    }
}