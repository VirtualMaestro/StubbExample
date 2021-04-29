using System.Collections.Generic;
using StubbUnity.StubbFramework.Scenes.Configurations;
using StubbUnity.Unity.Scenes;

namespace Client.Source
{
    public static class SceneConfigs
    {
        private const string ScenePath = "Client/Scenes";
        
        public static readonly SceneName CameraSceneName;
        public static readonly SceneName CylinderSceneName;
        public static readonly SceneName SphereSceneName;
        public static readonly SceneName MenuSceneName;
        public static readonly SceneName PhysicsSceneName;

        public static readonly List<ILoadingSceneConfig> CameraSceneConfigs;
        public static readonly List<ILoadingSceneConfig> CylinderSceneConfigs;
        public static readonly List<ILoadingSceneConfig> SphereSceneConfigs;
        public static readonly List<ILoadingSceneConfig> MenuSceneConfigs;
        public static readonly List<ILoadingSceneConfig> AllScenesConfigs;
        public static readonly List<ILoadingSceneConfig> ThreeScenesConfigs;
        public static readonly List<ILoadingSceneConfig> PhysicsScenesConfigs;

        static SceneConfigs()
        {
            CameraSceneName = new SceneName("Camera", ScenePath);
            CylinderSceneName = new SceneName("One", ScenePath);
            SphereSceneName = new SceneName("Two", ScenePath);
            MenuSceneName = new SceneName("Menu", ScenePath);
            PhysicsSceneName = new SceneName("Physics", ScenePath);

            CameraSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName).IsActive()
                .Build;

            CylinderSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CylinderSceneName).IsActive().IsMain()
                .Build;

            SphereSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(SphereSceneName).IsActive()
                .Build;

            MenuSceneConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(MenuSceneName).IsActive()
                .Build;

            AllScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CameraSceneName)
                .Add(CylinderSceneConfigs[0]).IsMain(false)
                .Add(SphereSceneName).IsActive().IsMain().IsMultiple()
                .Add(MenuSceneName)
                .Build;

            ThreeScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(CylinderSceneConfigs[0]).IsMain(false)
                .Add(SphereSceneName).IsActive().IsMain().IsMultiple()
                .Build;
            
            PhysicsScenesConfigs = SceneConfigsBuilder<LoadingSceneConfig, SceneName>.Create
                .Add(PhysicsSceneName).IsMain(true)
                .Build;
        }
    }
}