using Leopotam.Ecs;

public class ShotSettingsScreenDisableSystem : IEcsRunSystem
{
    private readonly EcsFilter<ShotSettingsScreenComponent> _shotSettingsScreenFilter;
    private readonly EcsFilter<ShotSettingsScreenDisableEvent> _disableEventFilter;

    public void Run()
    {
        if (_disableEventFilter.IsEmpty()) return;

        var screen = _shotSettingsScreenFilter.Get1(0).Screen;
        screen.SetActive(false);
        _disableEventFilter.GetEntity(0).Del<ShotSettingsScreenDisableEvent>();
    }
}