using Leopotam.Ecs;

public class TankCannonballHitSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, CannonballHitEvent>.Exclude<TankShotState> _hitTanksFilter;

    public void Run()
    {
        if (_hitTanksFilter.IsEmpty()) return;

        foreach (var i in _hitTanksFilter)
        {
            _hitTanksFilter.GetEntity(i).Get<FractureObjectHitEvent>();
        }
    }
}