using UnityEngine;

namespace AsteroidS
{
    public class AsteroidBuilder
    {
        private GameObject _asteroidObject;
        private Asteroid _asteroid;

        public AsteroidBuilder CreateAsteroid(Vector2 position)
        {
            _asteroidObject = new GameObject();
            _asteroidObject.transform.position = position;

            return this;
        }

        public AsteroidBuilder SetProperties(AsteroidProperties properties)
        {
            _asteroid = _asteroidObject.AddComponent<Asteroid>();
            var propsToSet = _asteroid.GetAsteroidProperties();
            propsToSet = properties;

            return this;
        }

        public AsteroidBuilder SetObjectView(Sprite[] sprites)
        {
            _asteroidObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            _asteroidObject.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);
            return this;
        }

        public Asteroid Get()
        {
            return _asteroid;
        }
    }
}
