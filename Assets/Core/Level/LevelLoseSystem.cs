using Leopotam.Ecs;
using UnityEngine;

public class LevelLoseSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<UndiedTankAppearedEvent> _undiedTankFilter;

    public void Run()
    {
        if (_undiedTankFilter.IsEmpty()) return;

        Debug.Log(2);

        _world.NewEntity().Get<LevelLostEvent>();

        foreach (var i in _undiedTankFilter)
        {
            _undiedTankFilter.GetEntity(i).Destroy();
        }
    }
}