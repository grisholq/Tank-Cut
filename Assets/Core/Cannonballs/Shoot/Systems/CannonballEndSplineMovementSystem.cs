using Leopotam.Ecs;

public class CannonballEndSplineMovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<CannonballTag, SplineFollowerComponent, CannonballSplineEndReachedEvent> _splineCannonballsFilter;

    public void Run()
    {
        if (_splineCannonballsFilter.IsEmpty()) return;

        foreach (var i in _splineCannonballsFilter)
        {
            var splineFollower = _splineCannonballsFilter.Get2(i).Follower;

            splineFollower.follow = false;

            _splineCannonballsFilter.GetEntity(i).Del<CannonballSplineEndReachedEvent>();

            _world.NewEntity().Get<CannonballMovementEndedEvent>();

        }
    }
}