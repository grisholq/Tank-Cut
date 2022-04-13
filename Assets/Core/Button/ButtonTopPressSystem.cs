using Leopotam.Ecs;
using UnityEngine;

public class ButtonTopPressSystem : IEcsRunSystem
{
    private readonly EcsFilter<ButtonTag, ButtonTop, ButtonTopPressedPosition, ButtonPressedEvent> _pressedButtonsFilter;

    public void Run()
    {
        if (_pressedButtonsFilter.IsEmpty()) return;

        foreach (var i in _pressedButtonsFilter)
        {
            var top = _pressedButtonsFilter.Get2(i).Top;
            var pressedPosition = _pressedButtonsFilter.Get3(i).Position.position;

            top.transform.position = pressedPosition;
        }
    }
}
