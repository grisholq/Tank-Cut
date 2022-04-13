using Leopotam.Ecs;
using UnityEngine;

public class CannonballStartSplineMovementSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, CannonSpline, SplineFollowerComponent, SplineMovementStarted> _startedCannonballsFilter;
    private readonly EcsFilter<CannonballsSpeed> _cannonballSpeedFilter;

    public void Run()
    {
        foreach (var i in _startedCannonballsFilter)
        {
            var speed = _cannonballSpeedFilter.Get1(0).Speed;
            var spline = _startedCannonballsFilter.Get2(i).Spline;
            var splineFollower = _startedCannonballsFilter.Get3(i).Follower;

            splineFollower.spline = spline;
            splineFollower.follow = true;
            splineFollower.followSpeed = speed;
        }
    }
}