using UnityEngine;
using Leopotam.Ecs;
using System;
using Voody.UniLeo;

[Serializable]
public struct TankIsTargetOf
{
    [SerializeField] private EntityReference[] References;

    public int TankCount => References.Length;

    public EcsEntity GetTank(int index)
    {
        return References[index].Entity;
    }
}