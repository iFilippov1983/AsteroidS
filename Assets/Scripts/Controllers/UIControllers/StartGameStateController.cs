using UnityEngine;

namespace AsteroidS
{
    internal class StartGameStateController
    {
        internal void StartGame(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI, GameObject deathScreen)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerUI.SetActive(true);
            deathScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}