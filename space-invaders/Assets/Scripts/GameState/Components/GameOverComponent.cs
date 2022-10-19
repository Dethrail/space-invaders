﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [GameState]
    [Unique]
    [Event(EventTarget.Any, EventType.Added)]
    [Event(EventTarget.Any, EventType.Removed)]
    public sealed class GameOverComponent : IComponent
    {
    }
}