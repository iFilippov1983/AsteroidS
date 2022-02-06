using UnityEngine;

namespace AsteroidS
{
    public sealed class SceneInitializer
    {
        private readonly ControllersProxy _controllers;
        private readonly GameData _gameData;
        private readonly MenuManagementController _menuManagementController;
        private readonly OnButtonEnterProxyController _onButtonEnterProxy;
        internal readonly UIComponentInitializer UIComponentInitializer;
        internal readonly GameStateController GameStateController;
#if UNITY_ANDROID
        internal readonly AndroidPlayerUIController AndroidPlayerUIController; 
#endif

        public SceneInitializer(ControllersProxy controllers, GameData gameData)
        {
            _controllers = controllers;
            _gameData = gameData;

            var uiInitialize = new UIInitializer(gameData);
            UIComponentInitializer = new UIComponentInitializer(gameData, uiInitialize);
            GameStateController = new GameStateController(uiInitialize, UIComponentInitializer);
            _menuManagementController = new MenuManagementController(gameData, UIComponentInitializer, GameStateController);
            _onButtonEnterProxy = new OnButtonEnterProxyController(UIComponentInitializer);
            
            controllers.Add(UIComponentInitializer);
            controllers.Add(GameStateController);
            controllers.Add(_menuManagementController);
            controllers.Add(_onButtonEnterProxy);
#if UNITY_ANDROID
            AndroidPlayerUIController = new AndroidPlayerUIController(UIComponentInitializer, GameStateController);
            _controllers.Add(AndroidPlayerUIController);      
#endif
        }

        public void LateInit
            (
            Transform player, 
            PlayerController playerController, 
            SpaceObjectsController spaceObjectsController
            )
        {
            var sceneController = new SceneController(_gameData, player);
            var playerHPManagmentController = new PlayerHPManagementController(UIComponentInitializer.PlayerUIView,
                GameStateController, spaceObjectsController);
            _controllers.Add(sceneController);
            _controllers.Add(playerHPManagmentController);
            _controllers.Add(new AudioController(_gameData, _menuManagementController, playerController.ShootingController, spaceObjectsController, _onButtonEnterProxy));
        }
    }
}
