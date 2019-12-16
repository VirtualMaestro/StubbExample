using Leopotam.Ecs;
using StubbUnity.Contexts;

namespace Source
{
    public class MyContext : UnityContext
    {
        protected override IEcsSystem InitUserSystems()
        {
            var initUserSystems = new EcsSystems(World, "My awesome systems");
            initUserSystems.Add(new MainSystem());
            return initUserSystems;
        }
    }
}
