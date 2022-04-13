using Leopotam.Ecs;

public class TankShotSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankClickEvent>.Exclude<DeathState> _clickedTanksFilter;
    private readonly EcsFilter<TankShotState> _shotTanksFilter;

    public void Run()
    {
        if (_clickedTanksFilter.IsEmpty() || _shotTanksFilter.IsEmpty() == false) return;

        foreach (var i in _clickedTanksFilter)
        {
            _clickedTanksFilter.GetEntity(i).Get<TankShootEvent>();
        }
    }
}