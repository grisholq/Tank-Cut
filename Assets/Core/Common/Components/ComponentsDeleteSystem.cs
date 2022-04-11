using Leopotam.Ecs;

public class ComponentsDeleteSystem<T> : IEcsRunSystem where T : struct
{
    private readonly EcsFilter<T> _eventsFilter;

    public void Run()
    {
        foreach (var i in _eventsFilter)
        {
            _eventsFilter.GetEntity(0).Del<T>();
        }
    }
}