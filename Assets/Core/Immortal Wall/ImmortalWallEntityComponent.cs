using Leopotam.Ecs;
using System;
using UnityEngine;
using Voody.UniLeo;

[Serializable]
public struct ImmortalWallEntityComponent
{
    public EntityReference WallReference;

    public EcsEntity Wall => WallReference.Entity;
}