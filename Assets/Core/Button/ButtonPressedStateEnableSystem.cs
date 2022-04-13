using Leopotam.Ecs;

public class ButtonPressedStateEnableSystem : IEcsRunSystem
{
    private readonly EcsFilter<ButtonTag, ButtonPressedEvent> _pressedButtonsFilter;

    public void Run()
    {
        if (_pressedButtonsFilter.IsEmpty()) return;

        foreach (var i in _pressedButtonsFilter)
        {
            _pressedButtonsFilter.GetEntity(i).Get<ButtonPressedState>();
        }
    }
}