using Leopotam.Ecs;
using UnityEngine;

public class CannonballImmobilizationSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballTag, RigidbodyComponent, CannonballImmobilizeEvent> _immobileCannonballsFilter;

    public void Run()
    {
        foreach (var i in _immobileCannonballsFilter)
        {
            var rigidbody = _immobileCannonballsFilter.Get2(i).Rigidbody;

            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;


            _immobileCannonballsFilter.GetEntity(i).Get<CannonballSplineEndReachedEvent>();
            _immobileCannonballsFilter.GetEntity(i).Del<CannonballImmobilizeEvent>();
        }
    }
}