using Leopotam.Ecs;
using UnityEngine;

public class TankFractureSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, CannonballHitEvent>.Exclude<TankShotState> _hitTanksFilter;

    public void Run()
    {
        foreach (var i in _hitTanksFilter)
        {
            _hitTanksFilter.GetEntity(i).Get<TankFractureEvent>();
        }   
    }
}