using Leopotam.Ecs;
using StubbFramework.Extensions;
using UnityEngine;

namespace Source
{
    public class MainSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        
        public void Run()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                _world.LoadScenes(SceneConfigs.OneSceneConfig);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                _world.LoadScenes(SceneConfigs.TwoSceneConfig, true);
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                _world.LoadScenes(SceneConfigs.BothScenesConfig, true);
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                _world.UnloadAllScenes();
            }
        }
    }
}