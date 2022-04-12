using Leopotam.Ecs;
using UnityEngine;

public class TankLoseCheckSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<TankTag, TankIsTargetOf> _tanksFilter;

    public void Run()
    {
        if (_tanksFilter.IsEmpty()) return;

        foreach (var i in _tanksFilter)
        {
            var tanks = _tanksFilter.Get2(i);

            if (HasAliveTanks(tanks) == false)
            {
                _world.NewEntity().Get<UndiedTankAppearedEvent>();
                return;
            }
        }
    }

    private bool HasAliveTanks(TankIsTargetOf tanks)
    {
        for (int c = 0; c < tanks.TankCount; c++)
        {
            if (tanks.GetTank(c).Has<TankDiedState>() == false)
            {
                return true;
            }
        }

        return false;
    }
}