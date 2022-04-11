using Leopotam.Ecs;

public class InizializeEntityRequestSystem : IEcsRunSystem
{
    private readonly EcsFilter<InizializeEntityRequest> _inizializeEntityFilter;

    public void Run()
    {
        foreach (var i in _inizializeEntityFilter)
        {
            EntityReference reference = _inizializeEntityFilter.Get1(i).Reference;

            reference.Entity = _inizializeEntityFilter.GetEntity(i);

            _inizializeEntityFilter.GetEntity(i).Del<InizializeEntityRequest>();
        }
    }
}