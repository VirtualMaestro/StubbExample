using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Systems;
using Source.UI;
using StubbUnity.StubbFramework.Extensions;
using StubbUnity.Unity.Contexts;

namespace Source
{
    public class MyContext : UnityContext
    {
        protected override IEcsSystem InitUserSystems()
        {
            var userSystems = new EcsSystems(World, "My awesome systems");
            userSystems.Add(new MainSystem());
            userSystems.AddFeature(new UIMenuFeature(World));
            EcsUiEmitter emitter = gameObject.GetComponent<EcsUiEmitter>();
            userSystems.InjectUi(emitter);
            return userSystems;
        }
    }
}
