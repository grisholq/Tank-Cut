using Leopotam.Ecs;

public class CannonballEndSplineMovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineMovePercent> _splineCannonballsFilter;

    public void Run()
    {
        if (_splineCannonballsFilter.IsEmpty()) return;

        foreach (var i in _splineCannonballsFilter)
        {
            var movePercent = _splineCannonballsFilter.Get3(i);

            if (movePercent.Percent >= 1)
            {
                EcsEntity cannonball = _splineCannonballsFilter.GetEntity(i);

                cannonball.Del<CannonSpline>();
                cannonball.Del<SplineMovePercent>();

                _world.NewEntity().Get<CannonballMovementEndedEvent>();
            }
        }
    }
}