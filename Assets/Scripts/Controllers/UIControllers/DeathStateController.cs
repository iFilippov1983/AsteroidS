using System;
using UnityEngine;

namespace AsteroidS
{
    internal class DeathStateController
    {
        internal void DeathState(GameObject mainMenu, GameObject settingsMenu, GameObject playerUI,
            GameObject deathScreen)
        {
            Time.timeScale = 0;
            mainMenu.SetActive(false);
            settingsMenu.SetActive(false);
            playerUI.SetActive(false);
            deathScreen.SetActive(true);
        }
    }
}