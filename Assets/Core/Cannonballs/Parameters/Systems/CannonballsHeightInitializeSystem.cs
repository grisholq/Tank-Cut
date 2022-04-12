using Leopotam.Ecs;
using UnityEngine;

public class CannonballsHeightInitializeSystem : IEcsInitSystem
{
    private readonly EcsWorld _world;

    public void Init()
    {
        ref var height = ref _world.NewEntity().Get<CannonballsHeight>();
        height.Height = 0;
    }
}