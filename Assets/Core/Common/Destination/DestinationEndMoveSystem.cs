using Leopotam.Ecs;
using UnityEngine;

public class DestinationEndMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, DestinationPoint, DestinationReachedState> _reachedDestinationsFilter;

    public void Run()
    {
        foreach (var i in _reachedDestinationsFilter)
        {
            var transform = _reachedDestinationsFilter.Get1(i).Transform;
            var point = _reachedDestinationsFilter.Get2(i).Point;

            if (transform.position == point)
            {
                _reachedDestinationsFilter.GetEntity(i).Del<DestinationMoveState>();
                _reachedDestinationsFilter.GetEntity(i).Get<DestinationReachedState>();
            }
        }
    }
}