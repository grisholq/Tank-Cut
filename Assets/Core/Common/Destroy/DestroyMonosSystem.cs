using UnityEngine;
using Leopotam.Ecs;

public class DestroyMonosSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformComponent, DestroyEvent> _deadMonosFilter;

    public void Run()
    {
        foreach (var i in _deadMonosFilter)
        {
            var transformComponent = _deadMonosFilter.Get1(i);

            Object.Destroy(transformComponent.Transform.gameObject);
        }
    }
}