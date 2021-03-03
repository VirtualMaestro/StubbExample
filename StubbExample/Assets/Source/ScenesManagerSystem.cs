using Leopotam.Ecs;
using StubbUnity.StubbFramework.Extensions;
using UnityEngine;

namespace Source
{
    public class ScenesManagerSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        
        public void Run()
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                _world.LoadScenes(SceneConfigs.CameraSceneConfigs);
            }

            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                _world.LoadScenes(SceneConfigs.OneSceneConfigs);
            }

            if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                _world.LoadScenes(SceneConfigs.TwoSceneConfigs);
            }

            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                _world.LoadScenes(SceneConfigs.MenuSceneConfigs);
            }

            if (Input.GetKeyUp(KeyCode.Alpha5))
            {
                _world.LoadScenes(SceneConfigs.AllScenesConfigs, true);
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                _world.UnloadAllScenes();
            }
        }
    }
}