using UnityEngine;
using Leopotam.Ecs;

public abstract class EntityCollisionMono : MonoBehaviour
{
    [SerializeField] private EntityReference _entityReference;

    public EcsEntity Entity => _entityReference.Entity;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out EntityReference reference))
        {
            HandleCollision(reference);
        }
    }

    protected abstract void HandleCollision(EntityReference reference);
}