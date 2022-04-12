using Leopotam.Ecs;
using UnityEngine;

public class SplineMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<SplineMovePercent, SplineMoveSpeed> _splinesFilter;

    public void Run()
    {
        if (_splinesFilter.IsEmpty()) return;

        foreach (var i in _splinesFilter)
        {
            ref var movePercent = ref _splinesFilter.Get1(i);
            var speed = _splinesFilter.Get2(i).Speed;

            movePercent.Percent += speed * Time.deltaTime;
            movePercent.Percent = Mathf.Min(1, movePercent.Percent);
        }
    }
}