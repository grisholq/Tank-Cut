using Leopotam.Ecs;
using System;
using Voody.UniLeo;

[Serializable]
public struct TankTargets
{
    public EntityReference[] Targets;

    public int TargetsCount => Targets.Length;

    public EcsEntity GetTarget(int index)
    {
        return Targets[index].Entity;
    }
}