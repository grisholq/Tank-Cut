using Leopotam.Ecs;
using UnityEngine;

public class TankShotMarkSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankShootEvent> _shootedTanksFilter;

    public void Run()
    {
        foreach (var i in _shootedTanksFilter)
        {
            _shootedTanksFilter.GetEntity(i).Get<TankShotState>();
        }
    }
}