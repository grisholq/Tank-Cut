using Leopotam.Ecs;
using UnityEngine;

public class CannonballSplinePositionsResetSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineInitialPositions, SplineMovementEnded> _splineCannonballFilter;

    public void Run()
    {
        if (_splineCannonballFilter.IsEmpty()) return;

        foreach (var i in _splineCannonballFilter)
        {
            var spline = _splineCannonballFilter.Get2(i).Spline;
            var positions = _splineCannonballFilter.Get3(i);

            for (int c = 0; c < spline.pointCount; c++)
            {
                spline.SetPointPosition(c, positions.Positions[c]);
            }

            EcsEntity cannonball = _splineCannonballFilter.GetEntity(i);
            cannonball.Del<SplineInitialPositions>();
        }
    }
}