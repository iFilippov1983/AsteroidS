using UnityEditor;
using UnityEngine;

namespace AsteroidS
{
    internal class ExitStateController
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