using Leopotam.Ecs;

public static class DestinationSystemsExtension
{
    public static void AddDestinationSystems(this EcsSystems systems)
    {
        systems.Add(new DestinationInitializationSystem());
        systems.Add(new DestinationStartMoveSystem());
        systems.Add(new DestinationMoveSystem());
        systems.Add(new DestinationEndMoveSystem());
    }
}