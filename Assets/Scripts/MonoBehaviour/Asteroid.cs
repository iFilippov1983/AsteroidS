using UnityEngine;

namespace AsteroidS
{
    public abstract class Asteroid : MonoBehaviour
    {
        public abstract Sprite[] GetSprites();
        public abstract AsteroidProperties GetAsteroidProperties();
    }
}
