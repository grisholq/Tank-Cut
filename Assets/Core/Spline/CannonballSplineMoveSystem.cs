using Leopotam.Ecs;
using UnityEngine;

public class CannonballSplineMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, SplineMovePercent> _splinesFilter;
    private readonly EcsFilter<CannonballsSpeed> _cannonballsSpeedFilter;

    public void Run()
    {
        if (_splinesFilter.IsEmpty()) return;

        foreach (var i in _splinesFilter)
        {
            ref var movePercent = ref _splinesFilter.Get2(i);
            var speed = _cannonballsSpeedFilter.Get1(i).Speed;

            movePercent.Percent += speed * Time.deltaTime;
            movePercent.Percent = Mathf.Min(1, movePercent.Percent);
        }
    }
}