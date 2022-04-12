using Leopotam.Ecs;
using UnityEngine;

public class LevelWinSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<OneTankLeftEvent> _oneTankFilter;

    public void Run()
    {
        if (_oneTankFilter.IsEmpty()) return;
        _world.NewEntity().Get<LevelWonEvent>();

        foreach (var i in _oneTankFilter)
        {
            _oneTankFilter.GetEntity(i).Destroy();
        }
    }
}
