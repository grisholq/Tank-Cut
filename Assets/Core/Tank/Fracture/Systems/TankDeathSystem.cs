using Leopotam.Ecs;
using UnityEngine;

public class TankDeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankFractureEvent> _fracturedTanksFilter;

    public void Run()
    {
        if (_fracturedTanksFilter.IsEmpty()) return;

        foreach (var i in _fracturedTanksFilter)
        {
            _fracturedTanksFilter.GetEntity(i).Get<DeathState>();
        }
    }
}