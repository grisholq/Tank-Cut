using Leopotam.Ecs;

public class ImmortalWallCollisionMono : EntityTriggerMono
{
    protected override void HandleTriggerEnter(EntityReference reference)
    {
        EcsEntity entity = reference.Entity;

        if(entity.Has<CannonballTag>())
        {
            entity.Get<CannonballImmobilizeEvent>();
        }
    }
}
