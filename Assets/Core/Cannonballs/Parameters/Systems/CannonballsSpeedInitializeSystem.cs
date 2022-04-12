using Leopotam.Ecs;
using UnityEngine;

public class CannonballsSpeedInitializeSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;

    public void Init()
    {
        ref var speed = ref _world.NewEntity().Get<CannonballsSpeed>();
        speed.Speed = 0;
    }
}