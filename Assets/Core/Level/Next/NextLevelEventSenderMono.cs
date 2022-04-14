using Leopotam.Ecs;
using Voody.UniLeo;

public class NextLevelEventSenderMono : EcsGlobalEventSenderMono
{
    public override void SendEvent()
    {
        WorldHandler.GetWorld().NewEntity().Get<NextLevelEvent>();   
    }
}
