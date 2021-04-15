using Leopotam.Ecs;
using StubbUnity.StubbFramework.Logging;
using StubbUnity.StubbFramework.Scenes.Components;
using StubbUnity.StubbFramework.Scenes.Events;

namespace Client.Source.Systems
{
    public class ScenesHandlerSystem : IEcsRunSystem
    {
        private EcsFilter<SceneComponent, SceneReadyComponent> _scenesReadyFilter;
        private EcsFilter<SceneUnloadingCompleteEvent> _sceneUnloadingCompleteFilter;
        private EcsFilter<ScenesSetUnloadingCompleteEvent> _scenesSetUnloadingCompleteFilter;
        private EcsFilter<ScenesSetLoadingCompleteEvent> _scenesSetLoadingCompleteFilter;
        
        public void Run()
        {
            if (!_scenesReadyFilter.IsEmpty())
            {
                foreach (var idx in _scenesReadyFilter)
                {
                    ref var sceneComponent = ref _scenesReadyFilter.Get1(idx);
                    log.Warn($"Scene: {sceneComponent.Scene.SceneName} is ready to use!");
                }
            }
            
            if (!_scenesSetLoadingCompleteFilter.IsEmpty())
            {
                foreach (var idx in _scenesSetLoadingCompleteFilter)
                {
                    ref var sceneSetLoadingComplete = ref _scenesSetLoadingCompleteFilter.Get1(idx);
                    log.Warn($"Scenes config: {sceneSetLoadingComplete.ScenesSetName} has been loaded!");
                }
            }

            if (!_sceneUnloadingCompleteFilter.IsEmpty())
            {
                foreach (var idx in _sceneUnloadingCompleteFilter)
                {
                    ref var sceneUnloadingComplete = ref _sceneUnloadingCompleteFilter.Get1(idx);
                    log.Warn($"Scene: {sceneUnloadingComplete.SceneName} has been unloaded!");
                }
            }

            if (!_scenesSetUnloadingCompleteFilter.IsEmpty())
            {
                foreach (var idx in _scenesSetUnloadingCompleteFilter)
                {
                    ref var sceneSetUnloadingComplete = ref _scenesSetUnloadingCompleteFilter.Get1(idx);
                    log.Warn($"Scenes config: {sceneSetUnloadingComplete.ScenesSetName} has been unloaded!");
                }
            }
        }
    }
}