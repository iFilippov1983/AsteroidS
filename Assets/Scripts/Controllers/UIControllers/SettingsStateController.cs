using UnityEngine;

namespace AsteroidS
{
    internal class SettingsStateController
    {
        internal void SettingsMenu(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI, GameObject deathScreen) 
        {
            Time.timeScale = 0;
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
            playerUI.SetActive(false);
            deathScreen.SetActive(false);
        }
    }
}
