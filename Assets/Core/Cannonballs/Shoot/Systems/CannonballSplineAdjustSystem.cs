using Leopotam.Ecs;
using UnityEngine;

public class CannonballSplineAdjustSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineMovementStarted> _startCannonsFilter;
    private readonly EcsFilter<CannonballsHeight, CannonballsSpeed> _cannonballsSettingsFilter;

    public void Run()
    {
        if (_startCannonsFilter.IsEmpty()) return;

        foreach (var i in _startCannonsFilter)
        {
            float height = _cannonballsSettingsFilter.Get1(0).Height;
            float speed = _cannonballsSettingsFilter.Get2(0).Speed;

            var spline = _startCannonsFilter.Get2(i).Spline;

            Vector3 secondPoint = spline.GetPointPosition(1);
            Vector3 thirdPoint = spline.GetPointPosition(2);

            Vector3 delta = thirdPoint - secondPoint;
            delta = delta.normalized;
            delta.y = 0;

            secondPoint += delta * (speed / 2);
            secondPoint.y += height;

            thirdPoint += delta * speed;

            spline.SetPointPosition(1, secondPoint);
            spline.SetPointPosition(2, thirdPoint);
        }
    }
}