using StubbUnity.StubbFramework.Core;
using StubbUnity.Unity;

namespace Client.Source
{
    public class AppEntry : EntryPoint
    {
        protected override void Construct(IStubbContext context)
        {
            base.Construct(context);
            context.MainFeature = new MainFeature();
        }
    }
}