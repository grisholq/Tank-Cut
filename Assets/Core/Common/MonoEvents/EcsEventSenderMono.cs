using UnityEngine;
using Leopotam.Ecs;

public abstract class EcsEventSenderMono : MonoBehaviour
{
    [SerializeField] private EntityReference _entityReference;

    protected EcsEntity Entity => _entityReference.Entity;

    protected abstract void SendEventToEntity();
}