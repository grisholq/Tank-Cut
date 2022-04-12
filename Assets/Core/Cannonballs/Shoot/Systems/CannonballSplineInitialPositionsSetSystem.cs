using Leopotam.Ecs;
using UnityEngine;

public class CannonballSplineInitialPositionsSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineMovementStarted> _startCannonballsFilter;

    public void Run()
    {
        if (_startCannonballsFilter.IsEmpty()) return;

        foreach (var i in _startCannonballsFilter)
        {
            SetInitialPositions(i);
        }
    }

    private void SetInitialPositions(int i)
    {
        var spline = _startCannonballsFilter.Get2(i).Spline;
        ref var positions = ref _startCannonballsFilter.GetEntity(i).Get<SplineInitialPositions>();

        positions.Positions = new System.Collections.Generic.List<Vector3>(spline.pointCount);

        for (int c = 0; c < spline.pointCount; c++)
        {
            positions.Positions.Add(spline.GetPointPosition(c));
        }
    }
}