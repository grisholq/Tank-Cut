using Leopotam.Ecs;
using UnityEngine;

public class TankShotStateResetSystem : IEcsRunSystem
{
    private EcsFilter<TankTag, TankShotState> _shotTankFilter;
    private EcsFilter<CannonballMovementEndedEvent> _endedCannonballFilter;

    public void Run()
    {
        if (_endedCannonballFilter.IsEmpty()) return;

        foreach (var i in _shotTankFilter)
        {
            _shotTankFilter.GetEntity(i).Del<TankShotState>();        
        }

        foreach (var i in _endedCannonballFilter)
        {
            _endedCannonballFilter.GetEntity(i).Destroy();
        }
    }
}