using Leopotam.Ecs;

public static class LevelSystemsExtension
{
    public static void AddLevelSystems(this EcsSystems systems)
    {
        systems.Add(new LevelWinSystem());
        systems.Add(new LevelLoseSystem());
        systems.Add(new LevelRestartSystem());

        systems.Add(new LevelWinScreenSystem());
        systems.Add(new LevelLoseScreenSystem());
    }
}