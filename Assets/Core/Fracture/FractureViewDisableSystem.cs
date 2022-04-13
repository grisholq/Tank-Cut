using Leopotam.Ecs;
using UnityEngine;

public class FractureViewDisableSystem : IEcsRunSystem
{
    private readonly EcsFilter<FractureViewComponent, FractureEvent> _fractureViewsFilter;

    public void Run()
    {
        foreach (var i in _fractureViewsFilter)
        {
            var view = _fractureViewsFilter.Get1(i).View;
            view.SetActive(false);
        }
    }
}
