using Leopotam.Ecs;
using StubbUnity.StubbFramework.Logging;
using StubbUnity.StubbFramework.Physics.Components;

namespace Client.Source.Physics
{
    public class CollisionHandlingSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private readonly EcsFilter<CollisionEnterComponent> _collisionEnterFilter = null;
       
        public void Run()
        {
            if (_collisionEnterFilter.IsEmpty()) return;

            ref var collisionEnterComponent = ref _collisionEnterFilter.Get1(0);
            
            log.Warn($"ObjectA Name: {collisionEnterComponent.ObjectA.Name}, TypeId: {collisionEnterComponent.ObjectA.TypeId}");
            log.Warn($"ObjectB Name: {collisionEnterComponent.ObjectB.Name}, TypeId: {collisionEnterComponent.ObjectB.TypeId}");
            log.Warn($"Info: {collisionEnterComponent.Info}");
            
            // _world.T
        }
    }
}