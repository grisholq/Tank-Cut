using Leopotam.Ecs;

public class TankCannonballStartSetSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TransformComponent, CannonballEntitySpawnedEvent> _shotTanksFilter;

    public void Run()
    {
        foreach (var i in _shotTanksFilter)
        {
            var cannonball = _shotTanksFilter.Get3(i).Entity;
            var transform = _shotTanksFilter.Get2(i).Transform;

            cannonball.Get<CannonballShotStart>().Start = transform;
        }
    }
}