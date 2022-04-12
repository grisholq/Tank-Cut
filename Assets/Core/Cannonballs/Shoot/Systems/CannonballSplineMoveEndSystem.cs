using Leopotam.Ecs;

public class CannonballSplineMoveEndSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineMovePercent, SplineMoveSpeed, SplineMovementEnded> _splineCannonballsFilter;

    public void Run()
    {
        foreach (var i in _splineCannonballsFilter)
        {
            EcsEntity cannonball = _splineCannonballsFilter.GetEntity(i);

            cannonball.Del<CannonSpline>();
            cannonball.Del<SplineMovePercent>();
            cannonball.Del<SplineMoveSpeed>();
        }
    }
}