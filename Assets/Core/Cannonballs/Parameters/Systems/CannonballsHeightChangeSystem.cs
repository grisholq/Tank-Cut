using Leopotam.Ecs;

public class CannonballsHeightChangeSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballsHeight> _cannonballsHeightFilter;
    private readonly EcsFilter<CannonballChangeHeightEvent> _cannonballsEventFilter;

    public void Run()
    {
        if (_cannonballsEventFilter.IsEmpty()) return;

        var newHeight = _cannonballsEventFilter.Get1(0).Height;
        ref var cannonballHeight = ref _cannonballsHeightFilter.Get1(0);
        cannonballHeight.Height = newHeight;
    }
}