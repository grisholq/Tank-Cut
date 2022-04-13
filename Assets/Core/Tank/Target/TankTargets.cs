using Leopotam.Ecs;

public struct TankTargets
{
    public EntityReference[] Targets;

    public int TargetsCount => Targets.Length;

    public EcsEntity GetTarget(int index)
    {
        return Targets[index].Entity;
    }
}