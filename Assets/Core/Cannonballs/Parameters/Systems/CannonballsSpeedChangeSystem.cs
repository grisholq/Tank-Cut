using Leopotam.Ecs;

public class CannonballsSpeedChangeSystem : IEcsRunSystem
{
    private readonly EcsFilter<CannonballsSpeed> _cannonballsSpeedFilter;
    private readonly EcsFilter<CannonballChangeSpeedEvent> _cannonballsEventFilter;

    public void Run()
    {
        if (_cannonballsEventFilter.IsEmpty()) return;

        var newSpeed = _cannonballsEventFilter.Get1(0).Speed;
        ref var cannonballSpeed = ref _cannonballsSpeedFilter.Get1(0);
        cannonballSpeed.Speed = newSpeed;
    }
}