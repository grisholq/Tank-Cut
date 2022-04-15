using UnityEngine;
using Leopotam.Ecs;

public class ClickInputSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<LevelEndState> _endLevelFilter;

    public void Run()
    {
        if (_endLevelFilter.IsEmpty() == false) return; 

        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            ref var clickInputEvent = ref _world.NewEntity().Get<ClickInputEvent>();
            clickInputEvent.Point = Input.mousePosition;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ref var clickInputEvent = ref _world.NewEntity().Get<ClickInputEvent>();
            clickInputEvent.Point = Input.mousePosition;
        }
    }
}