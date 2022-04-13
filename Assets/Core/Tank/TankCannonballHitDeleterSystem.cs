using Leopotam.Ecs;
using UnityEngine;

public class TankCannonballHitDeleterSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankShotState, CannonballHitEvent> _hitTanksFilter;

    public void Run()
    {
        if (_hitTanksFilter.IsEmpty()) return;

        foreach (var i in _hitTanksFilter)
        {
            _hitTanksFilter.GetEntity(i).Del<CannonballHitEvent>();
        }   
    }
}