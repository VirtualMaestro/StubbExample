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
        
        public static readonly List<ILoadingSceneConfig> CameraSceneConfigs;
        public static readonly List<ILoadingSceneConfig> OneSceneConfigs;
        public static readonly List<ILoadingSceneConfig> TwoSceneConfigs;
        public static readonly List<ILoadingSceneConfig> AllScenesConfigs;
        
        static SceneConfigs()
        {
            CameraSceneName = new SceneName("Camera", "Scenes");
            OneSceneName = new SceneName("One", "Scenes");
            TwoSceneName = new SceneName("Two", "Scenes");
            
            CameraSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName).IsActive()
                .Build;
            
            OneSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(OneSceneName).IsActive().IsMain()
                .Build;
            
            TwoSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(TwoSceneName).IsActive()
                .Build;
            
            AllScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName)
                .Add(OneSceneConfigs[0]).IsMain(false)
                .Add(TwoSceneName).IsMain()
                .Build;
        }
    }
}