using Leopotam.Ecs;

public class CannonSplineEndReachedEventSenderMono : EcsEventSenderMono
{
    public override void SendEventToEntity()
    {
        Entity.Get<CannonballSplineEndReachedEvent>();
    }
}