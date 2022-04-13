using Leopotam.Ecs;

public struct ImmortalWallEntityComponent
{
    public EntityReference WallReference;

    public EcsEntity Wall => WallReference.Entity;
}