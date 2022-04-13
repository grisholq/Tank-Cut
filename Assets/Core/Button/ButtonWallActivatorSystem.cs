using Leopotam.Ecs;

public class ButtonWallActivatorSystem : IEcsRunSystem
{
    private readonly EcsFilter<ButtonTag, ButtonPressedEvent, ImmortalWallEntityComponent> _pressedButtonsFilter;

    public void Run()
    {
        foreach (var i in _pressedButtonsFilter)
        {
            var wall = _pressedButtonsFilter.Get3(i).Wall;

            wall.Get<DestinationStartMoveEvent>();
        }
    }
}