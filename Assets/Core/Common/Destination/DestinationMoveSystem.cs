using Leopotam.Ecs;
using UnityEngine;

public class DestinationMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, DestinationPoint, MovementSpeed, DestinationMoveState> _movingToDestinationFilter;

    public void Run()
    {
        foreach (var i in _movingToDestinationFilter)
        {
            var transform = _movingToDestinationFilter.Get1(i).Transform;
            var point = _movingToDestinationFilter.Get2(i).Point;
            var speed = _movingToDestinationFilter.Get3(i).Speed;

            transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime * speed);
        }
    }
}