using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AsteroidS
{
    public class SceneInitializer : IInitialization
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

            foreach (Object p in prefabs)
            {
                var obj = Object.Instantiate(p);

                if (obj is Canvas) SetCameraForBackground(obj);
            }
        }

        private void SetCameraForBackground(Object obj)
        {
            var back = (Canvas)obj;
            back.worldCamera = Object.FindObjectOfType<Camera>();
        }
    }
}
