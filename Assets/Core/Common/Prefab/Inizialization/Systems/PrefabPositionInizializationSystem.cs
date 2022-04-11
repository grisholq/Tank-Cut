using Leopotam.Ecs;

public class PrefabPositionInizializationSystem : IEcsRunSystem
{
    private readonly EcsFilter<PrefabInizializationState, TransformComponent, PositionComponent> _prefabsFilter;

    public void Run()
    {
        foreach (var i in _prefabsFilter)
        {
            var transform = _prefabsFilter.Get2(i).Transform;
            var position = _prefabsFilter.Get3(i).Position;

            transform.position = position;
        }
    }
}