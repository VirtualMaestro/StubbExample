using Client.Source.Physics;
using StubbUnity.StubbFramework.Core;
using StubbUnity.StubbFramework.Physics;
using StubbUnity.Unity;

namespace Client.Source
{
    public class AppEntry : EntryPoint
    {
        protected override void Construct(IStubbContext context)
        {
            base.Construct(context);
            context.MainFeature = new MainFeature();
        }

        protected override IPhysicsContext CreatePhysicsContext()
        {
            var physicsContext = new PhysicsContext(World)
            {
                HeadFeature = new PhysicsFeature()
            };
            
            return physicsContext;
        }
    }
}