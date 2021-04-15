using System.Collections.Generic;
using StubbUnity.StubbFramework.Scenes.Configurations;
using StubbUnity.Unity.Scenes;

namespace Client.Source
{
    public static class SceneConfigs
    {
        private const string ScenePath = "Client/Scenes";
        
        public static readonly SceneName CameraSceneName;
        public static readonly SceneName OneSceneName;
        public static readonly SceneName TwoSceneName;
        public static readonly SceneName MenuSceneName;

        public static readonly List<ILoadingSceneConfig> CameraSceneConfigs;
        public static readonly List<ILoadingSceneConfig> OneSceneConfigs;
        public static readonly List<ILoadingSceneConfig> TwoSceneConfigs;
        public static readonly List<ILoadingSceneConfig> MenuSceneConfigs;
        public static readonly List<ILoadingSceneConfig> AllScenesConfigs;
        public static readonly List<ILoadingSceneConfig> ThreeScenesConfigs;

        static SceneConfigs()
        {
            CameraSceneName = new SceneName("Camera", ScenePath);
            OneSceneName = new SceneName("One", ScenePath);
            TwoSceneName = new SceneName("Two", ScenePath);
            MenuSceneName = new SceneName("Menu", ScenePath);

            CameraSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName).IsActive()
                .Build;

            OneSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(OneSceneName).IsActive().IsMain()
                .Build;

            TwoSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(TwoSceneName).IsActive()
                .Build;

            MenuSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(MenuSceneName).IsActive()
                .Build;

            AllScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName)
                .Add(OneSceneConfigs[0]).IsMain(false)
                .Add(TwoSceneName).IsActive().IsMain().IsMultiple()
                .Add(MenuSceneName)
                .Build;

            ThreeScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(OneSceneConfigs[0]).IsMain(false)
                .Add(TwoSceneName).IsActive().IsMain().IsMultiple()
                .Build;
        }
    }
}