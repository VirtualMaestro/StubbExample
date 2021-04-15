using Client.Source.Systems;
using Client.Source.UI;
using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core;
using StubbUnity.StubbFramework.Extensions;
using StubbUnity.Unity.Scenes;

namespace Client.Source
{
    public class MainFeature : EcsFeature, IEcsInitSystem
    {
        private EcsWorld _world;

        public MainFeature()
        {
            Add(new ScenesManagerSystem());
            Add(new ApplicationChangeStateSystem());
            Add(new ScenesHandlerSystem());
            Add(new UIMenuFeature());
        }

        public void Init()
        {
            // _world.LoadScenes(SceneConfigs.CameraSceneConfigs, true);
        }
    }
}