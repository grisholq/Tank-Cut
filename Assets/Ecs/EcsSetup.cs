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

        _systems.Add(new LevelWinScreenSystem());
        _systems.Add(new LevelLoseScreenSystem());

        _systems.Add(new SplineMoveSystem());
        _systems.Add(new SplineMoveEndSystem());

        _systems.Add(new InizializeEntityRequestSystem());

        _systems.Add(new ClickInputSystem());

        _systems.Add(new TankShotStateResetSystem());

        _systems.Add(new TankClickSystem());

        _systems.Add(new TankShotSystem());
        _systems.Add(new TankShotMarkSystem());

        _systems.Add(new TankCannonballSpawnSystem());
        _systems.Add(new TankCannonballSplineSetSystem());



        _systems.Add(new TankCannonEventsDeleterSystem());

        _systems.Add(new TankFractureSystem());
        _systems.Add(new TankDeathSystem());

        _systems.Add(new TankViewDisableSystem());
        _systems.Add(new TankPiecesEnableSystem());

        _systems.Add(new TankWinCheckSystem());
        _systems.Add(new TankLoseCheckSystem());


        _systems.Add(new CannonballSplineInitialPositionsSetSystem());
        _systems.Add(new CannonballSplineAdjustSystem());
        _systems.Add(new CannonballInizializeMovementSystem());

        _systems.Add(new CannonballSplinePositionUpdateSystem());

        _systems.Add(new CannonballSplinePositionsResetSystem());
        _systems.Add(new CannonballSplineMoveEndSystem());

        _systems.Add(new CannonballMovementEndSystem());

        _systems.Add(new CannonballsSpeedInitializeSystem());
        _systems.Add(new CannonballsHeightInitializeSystem());

        _systems.Add(new CannonballsHeightChangeSystem());
        _systems.Add(new CannonballsSpeedChangeSystem());
    }

    private void AddOneFrames()
    {
        _systems.OneFrame<TankShootEvent>();

        _systems.OneFrame<CannonballChangeHeightEvent>();
        _systems.OneFrame<CannonballChangeSpeedEvent>();

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