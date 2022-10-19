﻿using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Common
{
    [GameState]
    [Unique]
    [Event(EventTarget.Self)]
    public sealed class ActionCountComponent : IComponent
    {
        public int value;
    }
}
