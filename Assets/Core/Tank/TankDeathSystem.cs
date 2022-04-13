using Leopotam.Ecs;
using UnityEngine;

public class TankDeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, CannonballHitEvent> _cannonHitTanksFilter;

    public void Run()
    {
        if (_cannonHitTanksFilter.IsEmpty()) return;

        foreach (var i in _cannonHitTanksFilter)
        {
            _cannonHitTanksFilter.GetEntity(i).Get<DeathState>();
        }
    }
}