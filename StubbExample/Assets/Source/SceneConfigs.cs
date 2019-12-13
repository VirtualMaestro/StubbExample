using System.Collections.Generic;
using StubbFramework.Common.Names;
using StubbFramework.Scenes.Configurations;
using StubbUnity.Scenes;

namespace Source
{
    public static  class SceneConfigs
    {
        public static readonly SceneName CameraSceneName;
        public static readonly SceneName OneSceneName;
        public static readonly SceneName TwoSceneName;
        
        public static readonly List<ILoadingSceneConfig> CameraSceneConfig;
        public static readonly List<ILoadingSceneConfig> OneSceneConfig;
        public static readonly List<ILoadingSceneConfig> TwoSceneConfig;
        public static readonly List<ILoadingSceneConfig> AllScenesConfig;
        
        static SceneConfigs()
        {
            CameraSceneName = new SceneName("Camera", "Scenes");
            OneSceneName = new SceneName("One", "Scenes");
            TwoSceneName = new SceneName("Two", "Scenes");
            
            CameraSceneConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName)
                .Build;
            
            OneSceneConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(OneSceneName, true, true)
                .Build;
            
            TwoSceneConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(TwoSceneName, true, true)
                .Build;
            
            AllScenesConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName)
                .Add(OneSceneName)
                .Add(TwoSceneName, true, true)
                .Build;
        }
    }
}