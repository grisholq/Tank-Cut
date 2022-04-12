using Leopotam.Ecs;
using UnityEngine;

public class TankWinCheckSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<TankTag>.Exclude<DeathState> _tanksFilter;

    public void Run()
    {
        if(_tanksFilter.GetEntitiesCount() == 1)
        {
            _world.NewEntity().Get<OneTankLeftEvent>();
        }
    }
}