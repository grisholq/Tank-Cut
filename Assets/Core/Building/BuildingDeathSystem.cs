using Leopotam.Ecs;

public class BuildingDeathSystem : IEcsRunSystem
{
    private readonly EcsFilter<BuildingTag, CannonballHitEvent> _hittedBuildingsFilter;

    public void Run()
    {
        if (_hittedBuildingsFilter.IsEmpty()) return;

        foreach (var i in _hittedBuildingsFilter)
        {
            _hittedBuildingsFilter.GetEntity(i).Get<DeathState>();
        }
    }
}