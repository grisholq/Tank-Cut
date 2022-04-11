using Leopotam.Ecs;
using UnityEngine;

public class TankClickSystem : IEcsRunSystem
{
    private readonly EcsFilter<CameraComponent> _cameraFilter;
    private readonly EcsFilter<ClickInputEvent> _clicksFilter;

    public void Run()
    {
        if (_clicksFilter.IsEmpty()) return;
    
        bool hit = TryGetRaycastGameObject(out GameObject gameObject);
        bool hasEntity = TryGetEntityFromGameObject(gameObject, out EcsEntity entity);

        if(hit && hasEntity)
        {
            if (entity.Has<TankTag>())
            {
                entity.Get<TankClickEvent>();
            }            
        }
    }

    private bool TryGetRaycastGameObject(out GameObject gameObject)
    {
        Camera camera = _cameraFilter.Get1(0).Camera;
        Vector2 input = _clicksFilter.Get1(0).Point;

        Ray ray = camera.ScreenPointToRay(input);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            gameObject = hit.transform.gameObject;
            return true;
        }

        gameObject = null;
        return false;
    }

    private bool TryGetEntityFromGameObject(GameObject gameObject, out EcsEntity entity)
    {
        if (gameObject.TryGetComponent(out EntityReference reference))
        {
            entity = reference.Entity;
            return true;
        }

        entity = new EcsEntity();
        return false;
    }
}
