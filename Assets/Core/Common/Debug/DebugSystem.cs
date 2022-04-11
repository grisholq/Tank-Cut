using UnityEngine;
using Leopotam.Ecs;

public class DebugSystem : IEcsRunSystem
{
    private readonly EcsFilter<DebugMessage> _debugMessagesFitler;

    public void Run()
    {
        foreach (var i in _debugMessagesFitler)
        {
            var debugMessage = _debugMessagesFitler.Get1(i);
            Debug.Log(debugMessage.Message);
            _debugMessagesFitler.GetEntity(i).Del<DebugMessage>();
        }
    }
}