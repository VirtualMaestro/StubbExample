﻿using StubbUnity.StubbFramework.Core;
using StubbUnity.Unity;

namespace Source
{
    public class AppEntry : EntryPoint
    {
        protected override void SetupFeatures(IStubbContext context)
        {
            base.SetupFeatures(context);
            context.MainFeature = new MainFeature();
        }
    }
}