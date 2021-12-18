using UnityEngine;

namespace AsteroidS
{
    internal class DefaultStateController
    {
        internal void DefaultState(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
        }
    }
}