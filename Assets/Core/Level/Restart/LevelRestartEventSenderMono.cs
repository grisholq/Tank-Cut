using Leopotam.Ecs;
using Voody.UniLeo;

public class LevelRestartEventSenderMono : EcsGlobalEventSenderMono
{
    public override void SendEvent()
    {
        WorldHandler.GetWorld().NewEntity().Get<LevelRestartEvent>();
    }
}