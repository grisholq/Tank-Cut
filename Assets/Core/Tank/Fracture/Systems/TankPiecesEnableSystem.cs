using Leopotam.Ecs;
using UnityEngine;

public class TankPiecesEnableSystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag, TankPiecesComponent, TankFractureEvent> _fracturedTanksFilter;

    public void Run()
    {
        foreach (var i in _fracturedTanksFilter)
        {
            var pieces = _fracturedTanksFilter.Get2(i);

            pieces.PiecesParent.SetActive(true);
        }
    }
}
