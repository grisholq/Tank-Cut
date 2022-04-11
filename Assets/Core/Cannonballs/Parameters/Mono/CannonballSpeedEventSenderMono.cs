using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

public class CannonballSpeedEventSenderMono : MonoBehaviour
{
    public void SendEvent(float speed)
    {
        ref var cannonballSpeed = ref WorldHandler.GetWorld().NewEntity().Get<CannonballChangeSpeedEvent>();
        cannonballSpeed.Speed = speed;
        Debug.Log(speed);
    }
}