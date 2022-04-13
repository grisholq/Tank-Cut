using Leopotam.Ecs;
using UnityEngine;

public class BuildingCannonballHitSystem : IEcsRunSystem
{
    private readonly EcsFilter<BuildingTag, CannonballHitEvent> _hittedBuildingsFilter;

    public void Run()
    {
        if (_hittedBuildingsFilter.IsEmpty()) return;

        foreach (var i in _hittedBuildingsFilter)
        {
            _hittedBuildingsFilter.GetEntity(i).Get<FractureObjectHitEvent>();
        }
    }
}