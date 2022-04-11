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
        _systems.Add(new InizializeEntityRequestSystem());

        _systems.Add(new ClickInputSystem());

        _systems.Add(new TankClickSystem());

        _systems.Add(new CannonballsHeightChangeSystem());
        _systems.Add(new CannonballsSpeedChangeSystem());
    }

    private void AddOneFrames()
    {
        _systems.OneFrame<CannonballChangeHeightEvent>();
        _systems.OneFrame<CannonballChangeSpeedEvent>();
        _systems.OneFrame<ClickInputEvent>();
        _systems.OneFrame<TankClickEvent>();
    }

    private void Update()
    {
        _systems.Run();
    }
}