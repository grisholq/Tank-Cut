using Leopotam.Ecs;
using UnityEngine;

public class TankCannonHitDebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, CannonballHitEvent>.Exclude<TankShotState> _hitTanksFilter;

    public void Run()
    {
        foreach (var i in _hitTanksFilter)
        {
            Debug.Log(1);
            _hitTanksFilter.GetEntity(i).Del<CannonballHitEvent>();
        }
    }
}