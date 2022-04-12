using Leopotam.Ecs;

public class TankCannonballSplineSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, SplineComputerComponent, CannonballEntitySpawnedEvent> _tankCannonFilter;

    public void Run()
    {
        if (_tankCannonFilter.IsEmpty()) return;

        foreach (var i in _tankCannonFilter)
        {
            var splineComputer = _tankCannonFilter.Get2(i).SplineComputer;
            var cannonball = _tankCannonFilter.Get3(i).Entity;

            cannonball.Get<CannonSpline>().Spline = splineComputer;
            cannonball.Get<SplineMovementStarted>();
        }
    }
}