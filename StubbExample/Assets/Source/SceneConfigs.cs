using System.Collections.Generic;
using StubbFramework.Scenes.Configurations;
using StubbUnity.Scenes;

namespace Source
{
    public static  class SceneConfigs
    {
        public static readonly List<ILoadingSceneConfig> OneSceneConfig;
        public static readonly List<ILoadingSceneConfig> TwoSceneConfig;
        public static readonly List<ILoadingSceneConfig> BothScenesConfig;
        
        static SceneConfigs()
        {
            OneSceneConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add("One", "Scenes", true, true)
                .Build;
            
            TwoSceneConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add("Two", "Scenes", true, true)
                .Build;
            
            BothScenesConfig = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add("One", "Scenes")
                .Add("Two", "Scenes", true, true)
                .Build;
        }
    }
}