using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private readonly EcsFilter<DestroyEvent> _deadEntitiesFilter;

    public void Run()
    {
        foreach (var i in _deadEntitiesFilter)
        {
            _deadEntitiesFilter.GetEntity(i).Destroy();
        }
    }
}
