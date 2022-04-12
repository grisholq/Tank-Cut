using Leopotam.Ecs;

public class SplineMoveEndSystem : IEcsRunSystem
{
    private readonly EcsFilter<SplineMovePercent> _splinesFilter;

    public void Run()
    {
        if (_splinesFilter.IsEmpty()) return;

        foreach (var i in _splinesFilter)
        {
            ref var movePercent = ref _splinesFilter.Get1(i);

            if(movePercent.Percent >= 1)
            {
                _splinesFilter.GetEntity(i).Get<SplineMovementEnded>();
            }
        }
    }
}