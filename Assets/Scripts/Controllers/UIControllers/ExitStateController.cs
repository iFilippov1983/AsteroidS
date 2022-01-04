using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    internal sealed class ExitStateController
    {
        internal void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}