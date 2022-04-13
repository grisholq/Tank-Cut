using Leopotam.Ecs;
using UnityEngine;

public class DestinationInitializationSystem : IEcsRunSystem
{
    private readonly EcsFilter<DestinationRawPoint> _rawPointsFilter;

    public void Run()
    {
        foreach (var i in _rawPointsFilter)
        {
            var rawPoint = _rawPointsFilter.Get1(i).Point;
            ref var point = ref _rawPointsFilter.GetEntity(i).Get<DestinationPoint>();

            point.Point = rawPoint.position;

            _rawPointsFilter.GetEntity(i).Get<DestinationSleepState>();
            _rawPointsFilter.GetEntity(i).Del<DestinationRawPoint>();
        }
    }
}