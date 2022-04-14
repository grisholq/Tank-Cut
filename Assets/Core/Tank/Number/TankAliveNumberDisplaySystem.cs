using Leopotam.Ecs;
using UnityEngine;

public class TankAliveNumberDisplaySystem : IEcsRunSystem
{
    private readonly EcsFilter<TankTag> _allTanksFilter;
    private readonly EcsFilter<TankTag, DeathState> _deadTanksFilter;
    private readonly EcsFilter<TankNumberUIComponent> _numberUIFilter;

    public void Run()
    {
        var numberText = _numberUIFilter.Get1(0).Text;

        int tanksCount = _allTanksFilter.GetEntitiesCount();
        int deadTanksCount = _deadTanksFilter.GetEntitiesCount();

        numberText.text = deadTanksCount.ToString() + " / " + (tanksCount - 1).ToString();
    }
}
