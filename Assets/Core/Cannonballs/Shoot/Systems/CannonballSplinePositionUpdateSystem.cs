using Leopotam.Ecs;

public class CannonballSplinePositionUpdateSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, TransformComponent, CannonSpline, SplineMovePercent> _cannonSplineFilter;
 
    public void Run()
    {
        foreach (var i in _cannonSplineFilter)
        {
            var transform = _cannonSplineFilter.Get2(i).Transform;
            var spline = _cannonSplineFilter.Get3(i).Spline;
            var splineMovePercent = _cannonSplineFilter.Get4(i).Percent;

            transform.position = spline.EvaluatePosition(splineMovePercent);         
        }
    }
}