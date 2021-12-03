using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AsteroidS
{
    public class AsteroidsController : IInitialization, IExecute
    {
        private List<Asteroid> _asteroids;

        public AsteroidsController(List<Asteroid> asteroids)
        {
            _asteroids = asteroids;
        }

        public void Initialize()
        {
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.transform.position = new Vector3(1, 1, 0);
            }
        }

        public void Execute(float deltaTime)
        {
            
        }

        
    }
}
