using Leopotam.Ecs;

public static class PatrolSystemsExtension
{
   public static void AddPatrolSystems(this EcsSystems systems)
    {
        systems.Add(new PatrolInizializeSystem());
        systems.Add(new PatrolPointMoveSystem());
        systems.Add(new PatrolCurrentPointUpdateSystem());
        systems.Add(new PatrolNextPointUpdateSystem());
    }
}