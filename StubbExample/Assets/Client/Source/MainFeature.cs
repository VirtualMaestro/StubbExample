using Client.Source.Systems;
using Client.Source.UI;
using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core;

namespace Client.Source
{
    public class MainFeature : EcsFeature
    {
        private EcsWorld _world;

        public MainFeature()
        {
            Add(new ScenesManagerSystem());
            Add(new ApplicationChangeStateSystem());
            Add(new ScenesHandlerSystem());
            Add(new UIMenuFeature());
        }
    }
}