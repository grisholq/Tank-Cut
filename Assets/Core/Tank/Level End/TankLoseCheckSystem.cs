using Leopotam.Ecs;
using UnityEngine;

public class TankLoseCheckSystem : IEcsRunSystem
{
    private readonly EcsWorld _world;
    private readonly EcsFilter<TankTag, TankIsTargetOf>.Exclude<DeathState> _targetedTanksFilter;
    private readonly EcsFilter<TankTag, TankTargets>.Exclude<DeathState> _tanksTargetsFilter;

    public void Run()
    {
        if (_tanksTargetsFilter.IsEmpty() && _targetedTanksFilter.IsEmpty()) return;

        if(TanksDoNotHaveAims() && TanksNotTargeted())
        {
            _world.NewEntity().Get<TanksCannonBeShotOrTargeted>();
        }
    }

    private bool TanksDoNotHaveAims()
    {
        foreach (var i in _tanksTargetsFilter)
        {
            var tanks = _tanksTargetsFilter.Get2(i);

            if (HasAliveTargetTank(tanks))
            {
                return false;
            }
        }

        return true;
    }

    private bool TanksNotTargeted()
    {
        foreach (var i in _targetedTanksFilter)
        {
            var tanks = _targetedTanksFilter.Get2(i);

            if (HasAliveTanksAimingAt(tanks) == false)
            {
                return true;
            }
        }

        return false;
    }

    private bool HasAliveTanksAimingAt(TankIsTargetOf tanks)
    {
        for (int c = 0; c < tanks.TankCount; c++)
        {
            if (tanks.GetTank(c).Has<DeathState>() == false)
            {
                return true;
            }
        }

        return false;
    } 
    
    private bool HasAliveTargetTank(TankTargets targets)
    {
        for (int c = 0; c < targets.TargetsCount; c++)
        {
            EcsEntity target = targets.GetTarget(c);

            if (target.Has<TankTag>() && target.Has<DeathState>() == false)
            {
                return true;
            }
        }

        return false;
    }
}