using Leopotam.Ecs;
using UnityEngine;

public class DestinationStartMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<DestinationPoint, DestinationStartMoveEvent, DestinationSleepState> _sleepingDestinationsFilter;

    public void Run()
    {
        foreach (var i in _sleepingDestinationsFilter)
        {
            _sleepingDestinationsFilter.GetEntity(i).Del<DestinationStartMoveEvent>();
            _sleepingDestinationsFilter.GetEntity(i).Del<DestinationSleepState>();

            _sleepingDestinationsFilter.GetEntity(i).Get<DestinationMoveState>();
        }
    }
}