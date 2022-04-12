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
        _systems.Add(new LevelWinSystem());
        _systems.Add(new LevelLoseSystem());
        _systems.Add(new LevelRestartSystem());

        _systems.Add(new LevelWinScreenSystem());
        _systems.Add(new LevelLoseScreenSystem());

        _systems.Add(new InizializeEntityRequestSystem());

        _systems.Add(new ClickInputSystem());

        _systems.Add(new TankShotStateResetSystem());

        _systems.Add(new TankClickSystem());

        _systems.Add(new TankShotSystem());
        _systems.Add(new TankShotMarkSystem());

        _systems.Add(new TankCannonballSpawnSystem());

        _systems.Add(new TankCannonballSplineSetSystem());
        _systems.Add(new TankCannonballStartSetSystem());
        _systems.Add(new TankCannonballEndSetSystem());

        _systems.Add(new TankCannonEventsDeleterSystem());

        _systems.Add(new TankFractureSystem());
        _systems.Add(new TankDeathSystem());

        _systems.Add(new TankViewDisableSystem());
        _systems.Add(new TankPiecesEnableSystem());

        _systems.Add(new TankWinCheckSystem());
        _systems.Add(new TankLoseCheckSystem());



        _systems.Add(new CannonballSplineAdjustSystem());

        _systems.Add(new CannonballStartSplineMovementSystem());
        _systems.Add(new CannonballSplineMoveSystem());
        _systems.Add(new CannonballEndSplineMovementSystem());

        _systems.Add(new CannonballSplinePositionUpdateSystem());
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
    }

    private void Update()
    {
        _systems.Run();
    }
}