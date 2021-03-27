using System.Collections.Generic;
using StubbUnity.StubbFramework.Scenes.Configurations;
using StubbUnity.Unity.Scenes;

namespace Client.Source
{
    public static class SceneConfigs
    {
        public static readonly SceneName CameraSceneName;
        public static readonly SceneName OneSceneName;
        public static readonly SceneName TwoSceneName;
        public static readonly SceneName MenuSceneName;

        public static readonly List<ILoadingSceneConfig> CameraSceneConfigs;
        public static readonly List<ILoadingSceneConfig> OneSceneConfigs;
        public static readonly List<ILoadingSceneConfig> TwoSceneConfigs;
        public static readonly List<ILoadingSceneConfig> MenuSceneConfigs;
        public static readonly List<ILoadingSceneConfig> AllScenesConfigs;

        static SceneConfigs()
        {
            CameraSceneName = new SceneName("Camera", "Scenes");
            OneSceneName = new SceneName("One", "Scenes");
            TwoSceneName = new SceneName("Two", "Scenes");
            MenuSceneName = new SceneName("Menu", "Scenes");

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
        }
    }
}