using Leopotam.Ecs;
using StubbFramework;
using StubbFramework.Common.Components;
using StubbFramework.Scenes.Components;
using UnityEngine;

namespace Source.UI
{
    public class UIMenuFeature : EcsFeature, IEcsRunSystem
    {
        private readonly EcsFilter<SceneComponent, IsActiveComponent, SceneChangedStateComponent> _sceneActivatedFilter = null;
        private readonly EcsFilter<SceneComponent, IsInactiveComponent, SceneChangedStateComponent> _sceneDeactivatedFilter = null;
        
        public UIMenuFeature(EcsWorld world, string name = "UI", bool isEnable = true) : base(world, name, isEnable)
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
                    if (sceneActivated.Scene.SceneName.Name == SceneConfigs.UISceneName.Name)
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
                    if (sceneDeactivated.Scene.SceneName.Name == SceneConfigs.UISceneName.Name)
                    {
                        Enable = false;
                        Debug.Log($"Feature {Name} is now deactivated!");
                    }
                }
            }
        }
    }
}