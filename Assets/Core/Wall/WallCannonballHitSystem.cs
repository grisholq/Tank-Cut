using Leopotam.Ecs;
using UnityEngine;

public class WallCannonballHitSystem : IEcsRunSystem
{
    private readonly EcsFilter<WallTag, CannonballHitEvent> _hitWallsFilter;

    public void Run()
    {
        if (_hitWallsFilter.IsEmpty()) return;

        foreach (var i in _hitWallsFilter)
        {
            _hitWallsFilter.GetEntity(i).Get<FractureObjectHitEvent>();
        }
    }
}