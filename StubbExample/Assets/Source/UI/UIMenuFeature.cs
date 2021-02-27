using Leopotam.Ecs;
using StubbUnity.StubbFramework;
using StubbUnity.StubbFramework.Scenes.Components;
using UnityEngine;

namespace Source.UI
{
    public class UIMenuFeature : EcsFeature, IEcsRunSystem
    {
        private readonly EcsFilter<SceneComponent, IsSceneActiveComponent, SceneChangedStateComponent> _sceneActivatedFilter = null;
        private readonly EcsFilter<SceneComponent, IsSceneInactiveComponent, SceneChangedStateComponent> _sceneDeactivatedFilter = null;
        
        public UIMenuFeature(EcsWorld world, string name = "UI", bool isEnable = false) : base(world, name, isEnable)
        {
        }

        protected override void SetupSystems()
        {
            Add(new UIClickEventsHandlerSystem());
            Add(new UISlideEventsHandlerSystem());
        }

        public void Run()
        {
            if (!_sceneActivatedFilter.IsEmpty())
            {
                foreach (var idx in _sceneActivatedFilter)
                {
                    ref var sceneActivated = ref _sceneActivatedFilter.Get1(idx);
                    if (sceneActivated.Scene.SceneName.Name == SceneConfigs.MenuSceneName.Name)
                    {
                        Enable = true;
                        Debug.Log($"Feature {Name} is now activated!");
                    }
                }
            }

            if (!_sceneDeactivatedFilter.IsEmpty())
            {
                foreach (var idx in _sceneDeactivatedFilter)
                {
                    ref var sceneDeactivated = ref _sceneDeactivatedFilter.Get1(idx);
                    if (sceneDeactivated.Scene.SceneName.Name == SceneConfigs.MenuSceneName.Name)
                    {
                        Enable = false;
                        Debug.Log($"Feature {Name} is now deactivated!");
                    }
                }
            }
        }
    }
}