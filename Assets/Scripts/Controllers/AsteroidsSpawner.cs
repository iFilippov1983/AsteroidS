using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    public class AsteroidsSpawner
    {
        private Asteroid[] _asteroids;
        private AsteroidBuilder _asteroidBuilder;

        public AsteroidsSpawner(GameData gameData)
        {
            _asteroids = gameData.SceneData.AsteroidsPrefabs.ToArray();
            _asteroidBuilder = new AsteroidBuilder();
        }

        public List<Asteroid> GetAsteroids()
        {
            var asteroidObjects = new List<Asteroid>();
            for (int prefabIndex = 0; prefabIndex < _asteroids.Length; prefabIndex++)
            {
                var propeties = _asteroids[prefabIndex].GetAsteroidProperties();

                for (int amountIndex = 0; amountIndex < propeties.amountOnScene; amountIndex++)
                {
                    var obj = _asteroidBuilder
                            .CreateAsteroid(SetPosition())
                            .SetProperties(propeties)
                            .Get();

                    asteroidObjects.Add(obj);
                }
            }

            return asteroidObjects;
        }

        private Vector2 SetPosition()
        {
            return Vector2.zero;
        }
    }
}
