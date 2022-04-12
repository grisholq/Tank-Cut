using UnityEngine;
using Leopotam.Ecs;

public class CannonballCollisionMono : EntityTriggerMono
{
    protected override void HandleTriggerEnter(EntityReference reference)
    {
        EcsEntity entity = reference.Entity;
        entity.Get<CannonballHitEvent>();
    }
}