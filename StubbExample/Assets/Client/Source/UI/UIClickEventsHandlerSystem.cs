using Leopotam.Ecs;
using Leopotam.Ecs.Ui.Components;
using UnityEngine;

namespace Client.Source.UI
{
    public sealed class UIClickEventsHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EcsUiClickEvent> _clickEvents = null;
        
        public void Run()
        {
            if (_clickEvents.IsEmpty()) return;
            
            foreach (var idx in _clickEvents)
            {
                ref var data = ref _clickEvents.Get1(idx);
                Debug.Log($"Click was made by {data.WidgetName} sender is {data.Sender.name}");
            }
        }
    }
}