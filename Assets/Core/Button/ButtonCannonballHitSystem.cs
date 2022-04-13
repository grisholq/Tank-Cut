using Leopotam.Ecs;
using UnityEngine;

public class ButtonCannonballHitSystem : IEcsRunSystem
{
    private EcsFilter<ButtonTag, CannonballHitEvent>.Exclude<ButtonPressedState> _hitButtonsFilter;

    public void Run()
    {
        if (_hitButtonsFilter.IsEmpty()) return;

        foreach (var i in _hitButtonsFilter)
        {
            _hitButtonsFilter.GetEntity(i).Get<ButtonPressedEvent>();
        }
    }
}
