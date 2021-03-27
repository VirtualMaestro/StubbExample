using Client.Source.UI;
using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core;
using StubbUnity.StubbFramework.Extensions;

namespace Client.Source
{
    public class MainFeature : EcsFeature, IEcsInitSystem
    {
        private EcsWorld _world;
        
        public MainFeature()
        {
            Add(new ScenesManagerSystem());
            Add(new UIMenuFeature());
        }

        public void Init()
        {
            _world.LoadScenes(SceneConfigs.CameraSceneConfigs, true);
        }
    }
}