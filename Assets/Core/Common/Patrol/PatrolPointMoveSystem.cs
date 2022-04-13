using Leopotam.Ecs;
using UnityEngine;

public class PatrolPointMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, PatrolCurrentPoint, PatrolNextPoint, MovementSpeed> _patrolPointsFilter;

    public void Run()
    {
        if (_patrolPointsFilter.IsEmpty()) return;

        foreach (var i in _patrolPointsFilter)
        {
            var transform = _patrolPointsFilter.Get1(i).Transform;
            var currentPoint = _patrolPointsFilter.Get2(i);
            var nextPoint = _patrolPointsFilter.Get3(i);
            var speed = _patrolPointsFilter.Get4(i).Speed;

            transform.position = Vector3.MoveTowards(transform.position, nextPoint.Position, Time.deltaTime * speed);
            
            if(transform.position == nextPoint.Position)
            {
                _patrolPointsFilter.GetEntity(i).Get<PatrolPointReachedEvent>();
            }
        }
    }
}