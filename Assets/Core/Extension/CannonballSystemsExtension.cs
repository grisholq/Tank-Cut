using Leopotam.Ecs;

public static class CannonballSystemsExtension
{
    public static void AddCannonSystems(this EcsSystems systems)
    {
        systems.Add(new CannonballImmobilizationSystem());

        systems.Add(new CannonballSplineAdjustSystem());
        
        systems.Add(new CannonballStartSplineMovementSystem());
        systems.Add(new CannonballEndSplineMovementSystem());
    }
}