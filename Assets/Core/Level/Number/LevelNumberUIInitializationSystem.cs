using Leopotam.Ecs;
using UnityEngine;

public class LevelNumberUIInitializationSystem : IEcsInitSystem
{
    private readonly EcsFilter<LevelNumberUIComponent> _levelNumber;

    public void Init()
    {
        foreach (var i in _levelNumber)
        {
            var numberText = _levelNumber.Get1(i).Text;
            numberText.text = "Level " + LevelPassData.GetPassedLevels();
        }
    }
}
