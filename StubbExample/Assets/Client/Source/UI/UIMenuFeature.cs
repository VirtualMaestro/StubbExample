﻿using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core;
using StubbUnity.StubbFramework.Scenes.Components;
using UnityEngine;

namespace Client.Source.UI
{
    public class UIMenuFeature : EcsFeature, IEcsRunSystem
    {
        private readonly EcsFilter<SceneComponent, IsSceneActiveComponent, SceneBecomeActiveComponent> _sceneActivatedFilter = null;
        private readonly EcsFilter<SceneComponent, IsSceneInactiveComponent, SceneBecomeInactiveComponent> _sceneDeactivatedFilter = null;
        
        public UIMenuFeature() : base(false)
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
                    if (sceneActivated.Scene.SceneName.Equals(SceneConfigs.MenuSceneName))
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
                    if (sceneDeactivated.Scene.SceneName.Equals(SceneConfigs.MenuSceneName))
                    {
                        Enable = false;
                        Debug.Log($"Feature {Name} is now deactivated!");
                    }
                }
            }
        }
    }
}