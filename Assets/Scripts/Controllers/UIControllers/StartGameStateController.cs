using UnityEngine;

namespace AsteroidS
{
    internal class StartGameStateController
    {
        internal void StartGame(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerUI.SetActive(true);
            Time.timeScale = 1;
        }
    }
}