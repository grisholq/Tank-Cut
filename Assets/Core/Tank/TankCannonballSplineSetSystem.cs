using Leopotam.Ecs;

public class TankCannonballSplineSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, SplineComputerComponent, CannonballEntityComponent> _tankCannonFilter;

    public void Run()
    {
        foreach (var i in _tankCannonFilter)
        {
            var splineComputer = _tankCannonFilter.Get2(i).SplineComputer;
            var cannon = _tankCannonFilter.Get3(i).Entity;

            cannon.Get<CannonSpline>().Spline = splineComputer;
        }
    }
}