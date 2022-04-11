using Leopotam.Ecs;

public class PrefabForceInizializationSystem : IEcsRunSystem
{
    private readonly EcsFilter<PrefabInizializationState, RigidbodyComponent, ForceComponent> _prefabsFilter;

    public void Run()
    {
        foreach (var i in _prefabsFilter)
        {
            var rigidbody = _prefabsFilter.Get2(i).Rigidbody;
            var force = _prefabsFilter.Get3(i).Force;

            rigidbody.AddForce(force);
        }
    }
}