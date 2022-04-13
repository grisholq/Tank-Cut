using Leopotam.Ecs;
using UnityEngine;

public class ButtonToWallPathInizializeSystem : IEcsRunSystem
{
    private readonly EcsFilter<ButtonToWallPath, LineRendererComponent, PathPoints>.Exclude<PathInitializedState> _pathInizializeFilter;
    private readonly EcsFilter<LineRendererPathHeight> _pathHeightFilter;

    public void Run()
    {
        if (_pathInizializeFilter.IsEmpty()) return;

        foreach (var i in _pathInizializeFilter)
        {
            var pathHeight = _pathHeightFilter.Get1(i).Height;

            var lineRenderer = _pathInizializeFilter.Get2(i).LineRenderer;
            var positions = _pathInizializeFilter.Get3(i).Points;

            lineRenderer.positionCount = positions.Length;

            for (int c = 0; c < positions.Length; c++)
            {
                Vector3 position = positions[c].position;
                position.y = pathHeight;
                lineRenderer.SetPosition(c, position);
            }

            _pathInizializeFilter.GetEntity(i).Get<PathInitializedState>();
        }
    }
}