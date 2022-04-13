using Leopotam.Ecs;
using UnityEngine;

public class PatrolInizializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<PatrolRawPoints> _rawPointsFilter;

    public void Run()
    {
        if (_rawPointsFilter.IsEmpty()) return;

        foreach (var i in _rawPointsFilter)
        {
            var rawPoints = _rawPointsFilter.Get1(i).RawPoints;
            ref var patrolPoints = ref _rawPointsFilter.GetEntity(i).Get<PatrolPoints>();

            patrolPoints.Points = new Vector3[rawPoints.Length];

            for (int c = 0; c < rawPoints.Length; c++)
            {
                patrolPoints.Points[c] = rawPoints[c].position;
            }

            ref var currentPoint = ref _rawPointsFilter.GetEntity(i).Get<PatrolCurrentPoint>();
            ref var nextPoint = ref _rawPointsFilter.GetEntity(i).Get<PatrolNextPoint>();

            currentPoint.Index = 0;
            currentPoint.Position = patrolPoints.Points[0];

            nextPoint.Index = 1;
            nextPoint.Position = patrolPoints.Points[1];

            _rawPointsFilter.GetEntity(i).Del<PatrolRawPoints>();
        }
    }
}