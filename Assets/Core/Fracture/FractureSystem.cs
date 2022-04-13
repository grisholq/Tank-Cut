using Leopotam.Ecs;

public class FractureSystem : IEcsRunSystem
{
    public readonly EcsFilter<FractureViewComponent, FracturePiecesComponent, FractureObjectHitEvent> _hitFracturesFilter;

    public void Run()
    {
        foreach (var i in _hitFracturesFilter)
        {
            _hitFracturesFilter.GetEntity(i).Get<FractureEvent>();
            _hitFracturesFilter.GetEntity(i).Del<FractureObjectHitEvent>();
        }
    }
}