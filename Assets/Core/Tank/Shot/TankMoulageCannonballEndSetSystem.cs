using Leopotam.Ecs;
using UnityEngine;

public class TankMoulageCannonballEndSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankTargetMoulage, CannonballEntitySpawnedEvent> _shotTanksFilter;


    public void Run()
    {
        foreach (var i in _shotTanksFilter)
        {
            var targetMoulage = _shotTanksFilter.Get2(i).Target;
            var cannonball = _shotTanksFilter.Get3(i).Entity;
            ref var shotEnd = ref cannonball.Get<CannonballShotEnd>();

            shotEnd.End = targetMoulage;
            shotEnd.Infinite = true;
        }
    }
}