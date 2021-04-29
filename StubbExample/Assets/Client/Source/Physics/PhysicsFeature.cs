using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core;
using StubbUnity.StubbFramework.Extensions;

namespace Client.Source.Physics
{
    public class PhysicsFeature : EcsFeature, IEcsInitSystem
    {
        public PhysicsFeature()
        {
            Add(new CollisionHandlingSystem());
        }

        public void Init()
        {
            World.AddCollisionPair(1, 2); // plane/sphere
        }
    }
}