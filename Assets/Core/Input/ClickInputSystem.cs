using UnityEngine;
using Leopotam.Ecs;

public class ClickInputSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;

    public void Run()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ref var clickInputEvent = ref _world.NewEntity().Get<ClickInputEvent>();
            clickInputEvent.Point = Input.mousePosition;
        }
    }
}