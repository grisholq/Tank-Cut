using Leopotam.Ecs;
using UnityEngine;

public class CannonballSplineAdjustSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, CannonballShotStart, CannonballShotEnd, SplineMovementStarted> _cannonPositionsFilter;
    private readonly EcsFilter<CannonballsHeight> _cannonballHeightFilter;
    private readonly EcsFilter<CannonballsSpeed> _cannonballSpeedFilter;

    public void Run()
    {
        if (_cannonPositionsFilter.IsEmpty()) return;

        foreach (var i in _cannonPositionsFilter)
        {
            var shotEnd = _cannonPositionsFilter.Get4(i);

            if (shotEnd.Infinite)
            {
                CalculateInfiniteSpline(i);
            }
            else
            {
                CalculateNormalSpline(i);
            }
        }
    }

    private void CalculateNormalSpline(int i)
    {
        float height = _cannonballHeightFilter.Get1(0).Height;

        var spline = _cannonPositionsFilter.Get2(i).Spline;
        Vector3 startPosition = _cannonPositionsFilter.Get3(i).Start.position;
        Vector3 endPosition = _cannonPositionsFilter.Get4(i).End.position;

        endPosition.y = 0.1f;

        Vector3 midlePosition = (endPosition - startPosition);
        midlePosition.y = 0;
        midlePosition /= 2;
        midlePosition.y = (endPosition - startPosition).magnitude * height;


        spline.SetPointPosition(0, startPosition);
        spline.SetPointPosition(1, startPosition + midlePosition);
        spline.SetPointPosition(2, endPosition);
    }
    
    private void CalculateInfiniteSpline(int i)
    {
        var height = _cannonballHeightFilter.Get1(0).Height;

        var spline = _cannonPositionsFilter.Get2(i).Spline;
        Vector3 startPosition = _cannonPositionsFilter.Get3(i).Start.position;      
        Vector3 endPosition = _cannonPositionsFilter.Get4(i).End.position;

       
        endPosition = startPosition + (endPosition - startPosition).normalized * 5;
        endPosition.y = 0.1f;

        Vector3 midlePosition = endPosition - startPosition;
        midlePosition.y = 0;
        midlePosition /= 2;
        midlePosition.y = (endPosition - startPosition).magnitude * height;

        spline.SetPointPosition(0, startPosition);
        spline.SetPointPosition(1, startPosition + midlePosition);
        spline.SetPointPosition(2, endPosition);
    }
}