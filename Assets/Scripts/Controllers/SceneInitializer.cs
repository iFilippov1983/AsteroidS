using Object = UnityEngine.Object;

namespace AsteroidS
{
    class SceneInitializer : IInitialization
    {
        private GameData _gameData;

        public SceneInitializer(GameData gameData)
        {
            _gameData = gameData;
        }

        public void Initialize()
        {
            InitScene(_gameData);
        }

        private void InitScene(GameData gameData)
        {
            var sceneData = gameData.SceneData;
            var prefabs = sceneData.GetAllPrefabs();
            foreach (Object obj in prefabs)
            {
                Object.Instantiate(obj);
            }
        }
    }
}
