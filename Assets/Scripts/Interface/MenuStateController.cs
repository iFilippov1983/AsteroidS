using System;
using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    public abstract class MenuStateController
    {
        public Action<GameState> StateChanged;
        public abstract void Initialize();
        public abstract void Cleanup();
    }
}