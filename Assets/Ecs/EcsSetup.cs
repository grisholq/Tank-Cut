using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Dreamteck.Splines;

public class EcsSetup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Awake()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        AddSystems();
        AddOneFrames();

        _systems.ConvertScene();
        _systems.Init();      
    }

    private void AddSystems()
    {
        _systems.Add(new ButtonToWallPathInizializeSystem());

        _systems.Add(new InizializeEntityRequestSystem());
        _systems.Add(new ClickInputSystem());

        _systems.Add(new WallCannonballHitSystem());
        _systems.Add(new WallDeathSystem());

        _systems.Add(new ButtonCannonballHitSystem());
        _systems.Add(new ButtonTopPressSystem());
        _systems.Add(new ButtonWallActivatorSystem());
        _systems.Add(new ButtonPressedStateEnableSystem());
        _systems.Add(new ButtonDeathSystem());

        _systems.Add(new BuildingCannonballHitSystem());
        _systems.Add(new BuildingDeathSystem());

        _systems.AddLevelSystems();
        _systems.AddTankSystems();
        _systems.AddCannonSystems();

        _systems.AddPatrolSystems();
        _systems.AddDestinationSystems();

        _systems.Add(new FractureSystem());
        _systems.Add(new FractureViewDisableSystem());
        _systems.Add(new FracturePiecesEnableSystem());

    }

    private void AddOneFrames()
    {
        _systems.OneFrame<TankShootEvent>();

        _systems.OneFrame<CannonballEntitySpawnedEvent>();

        _systems.OneFrame<ClickInputEvent>();
        _systems.OneFrame<TankClickEvent>();

        _systems.OneFrame<SplineMovementStarted>();
        _systems.OneFrame<SplineMovementEnded>();

        _systems.OneFrame<LevelWonEvent>();
        _systems.OneFrame<LevelLostEvent>();

        _systems.OneFrame<FractureEvent>();

        _systems.OneFrame<CannonballHitEvent>();

        _systems.OneFrame<PatrolPointReachedEvent>();
        _systems.OneFrame<ButtonPressedEvent>();

        _systems.OneFrame<NextLevelEvent>();
    }

    private void Update()
    {
        _systems.Run();
    }
}