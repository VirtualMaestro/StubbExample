using Leopotam.Ecs;
using StubbUnity.StubbFramework.Core.Events;
using StubbUnity.StubbFramework.Logging;

namespace Client.Source.Systems
{
    public class ApplicationChangeStateSystem : IEcsRunSystem
    {
        private EcsFilter<ApplicationFocusOnEvent> _appFocusOnFilter;
        private EcsFilter<ApplicationFocusOffEvent> _appFocusOffFilter;
        private EcsFilter<ApplicationPauseOnEvent> _appPauseOnFilter;
        private EcsFilter<ApplicationPauseOffEvent> _appPauseOffFilter;
        private EcsFilter<ApplicationQuitEvent> _appQuitFilter;
        
        public void Run()
        {
            if (!_appFocusOnFilter.IsEmpty())
                log.Info($"App focus ON");

            if (!_appFocusOffFilter.IsEmpty())
                log.Info($"App focus OFF");

            if (!_appPauseOnFilter.IsEmpty())
                log.Info($"App pause ON");

            if (!_appPauseOffFilter.IsEmpty())
                log.Info($"App pause OFF");

            if (!_appQuitFilter.IsEmpty())
                log.Info($"App quit");
        }
    }
}