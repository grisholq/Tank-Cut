using UnityEngine;
using Leopotam.Ecs;

public abstract class EntityTriggerMono : MonoBehaviour
{
    [SerializeField] private EntityReference _entityReference;

    public EcsEntity Entity => _entityReference.Entity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EntityReference reference))
        {
            HandleTriggerEnter(reference);
        }
    }

    protected abstract void HandleTriggerEnter(EntityReference reference);
}