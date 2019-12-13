﻿using Leopotam.Ecs;
using Source;
using StubbUnity.Contexts;

public class MyContext : UnityContext
{
    protected override IEcsSystem InitUserSystems()
    {
        var initUserSystems = new EcsSystems(World, "My awesome systems");
        initUserSystems.Add(new MainSystem());
        return initUserSystems;
    }
}
