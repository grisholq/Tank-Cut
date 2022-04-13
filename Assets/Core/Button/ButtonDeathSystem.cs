using Leopotam.Ecs;
using UnityEngine;

public class ButtonDeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<ButtonTag, ButtonPressedEvent> _pressedButtonsFilter;

    public void Run()
    {
        if (_pressedButtonsFilter.IsEmpty()) return;

        foreach (var i in _pressedButtonsFilter)
        {
            _pressedButtonsFilter.GetEntity(i).Get<DeathState>();
        }
    }
}