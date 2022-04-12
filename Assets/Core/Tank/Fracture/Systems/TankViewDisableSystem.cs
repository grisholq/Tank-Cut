using Leopotam.Ecs;
using UnityEngine;

public class TankViewDisableSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankViewComponent, TankFractureEvent> _fracturedTanksFilter;

    public void Run()
    {
        foreach (var i in _fracturedTanksFilter)
        {
            var view = _fracturedTanksFilter.Get2(i);

            view.View.SetActive(false);
        }
    }
}