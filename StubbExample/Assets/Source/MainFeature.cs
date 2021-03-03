using Source.UI;
using StubbUnity.StubbFramework.Core;

namespace Source
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