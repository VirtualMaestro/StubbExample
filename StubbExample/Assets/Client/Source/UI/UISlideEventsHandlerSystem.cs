using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Client.Source.UI
{
    public sealed class UISlideEventsHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EcsUiSliderChangeEvent> _sliderChangeEvents = null;

        public void Run()
        {
            if (_sliderChangeEvents.IsEmpty()) return;

            foreach (var idx in _sliderChangeEvents)
            {
                ref var data = ref _sliderChangeEvents.Get1(idx);
                Debug.Log($"Slide was made by {data.WidgetName} sender is {data.Sender.name}");
            }
        }
    }
}