using Leopotam.Ecs;
using UnityEngine;

public class FracturePiecesEnableSystem : IEcsRunSystem
{
    private readonly EcsFilter<FracturePiecesComponent, FractureEvent> _fractureViewsFilter;

    public void Run()
    {
        foreach (var i in _fractureViewsFilter)
        {
            var pieces = _fractureViewsFilter.Get1(i).Parent;
            pieces.SetActive(true);
        }
    }
}
