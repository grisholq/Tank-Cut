using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class CannonballHeightEventSenderMono : MonoBehaviour
{
    public void SendEvent(float height)
    {
        ref var cannonballHeight = ref WorldHandler.GetWorld().NewEntity().Get<CannonballChangeHeightEvent>();
        cannonballHeight.Height = height;
    }
}