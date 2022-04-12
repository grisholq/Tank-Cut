using UnityEngine;
using Leopotam.Ecs;

public class TankCannonballEndSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankTargets, CannonballEntitySpawnedEvent> _shotTanksFilter;

    public void Run()
    {
        foreach (var i in _shotTanksFilter)
        {
            var tankTargets = _shotTanksFilter.Get2(i);
            var cannonball = _shotTanksFilter.Get3(i).Entity;
            ref var shotEnd = ref cannonball.Get<CannonballShotEnd>();

            for (int c = 0; c < tankTargets.TargetsCount; c++)
            {
                var target = tankTargets.GetTarget(c);

                if (target.Has<DeathState>() == false)
                {
                    shotEnd.End = target.Get<TransformComponent>().Transform;
                    shotEnd.Infinite = false;
                    return;
                }
            }

            shotEnd.End = tankTargets.GetTarget(0).Get<TransformComponent>().Transform;
            shotEnd.Infinite = true;         
        }
    }
}