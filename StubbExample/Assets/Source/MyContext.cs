using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using StubbUnity.Contexts;

namespace Source
{
    public class MyContext : UnityContext
    {
        protected override IEcsSystem InitUserSystems()
        {
            var userSystems = new EcsSystems(World, "My awesome systems");
            userSystems.Add(new MainSystem());
            // userSystems.Add(new UIMenuFeature(World));
            userSystems.InjectUi(GetComponent<EcsUiEmitter>());
            return userSystems;
        }
    }
}
