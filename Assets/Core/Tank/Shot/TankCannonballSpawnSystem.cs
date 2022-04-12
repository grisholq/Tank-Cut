using UnityEngine;
using Leopotam.Ecs;

public class TankCannonballSpawnSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TransformComponent, TankShootEvent> _clickedTanksFilter;
    private readonly EcsFilter<CannonballPrefab> _cannonballPrefabFitler;

    public void Run()
    {
        if (_clickedTanksFilter.IsEmpty()) return;

        foreach (var i in _clickedTanksFilter)
        {
            Transform tank = _clickedTanksFilter.Get2(0).Transform;
            GameObject prefab = _cannonballPrefabFitler.Get1(0).Cannonball;

            GameObject instance = Object.Instantiate(prefab);
            instance.transform.position = tank.position;

            EcsEntity entity = instance.GetComponent<EntityReference>().Entity;

            _clickedTanksFilter.GetEntity(i).Get<CannonballEntitySpawnedEvent>().Entity = entity;
        }
    }
}