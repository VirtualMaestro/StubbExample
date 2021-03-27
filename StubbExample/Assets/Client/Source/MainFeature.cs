using Client.Source.UI;
using StubbUnity.StubbFramework.Core;

namespace Client.Source
{
    public class MainFeature : EcsFeature
    {
        public MainFeature()
        {
            Add(new ScenesManagerSystem());
            Add(new UIMenuFeature());
        }
    }
}