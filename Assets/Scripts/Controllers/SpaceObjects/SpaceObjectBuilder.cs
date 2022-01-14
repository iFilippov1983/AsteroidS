using UnityEngine;

namespace AsteroidS
{
    public sealed class SpaceObjectBuilder
    {
        private SpaceObject _spaceObject;

        public SpaceObjectBuilder MakeInstance(SpaceObject prefab)
        {
            _spaceObject = Object.Instantiate(prefab);
            if (_spaceObject.Properties.Type == SpaceObjectType.Asteroid)
            {
                var mass = _spaceObject.Properties.Mass;
                _spaceObject.GetComponent<Rigidbody2D>().mass = mass;
                _spaceObject.transform.localScale = Vector3.one * mass;
            }

            return this;
        }

        public SpaceObjectBuilder MakeInstance(SpaceObject prefab, float mass)
        {
            _spaceObject = Object.Instantiate(prefab);
            _spaceObject.GetComponent<Rigidbody2D>().mass = mass;
            _spaceObject.transform.localScale = Vector3.one * mass;

            return this;
        }

        public SpaceObjectBuilder SetPosition(Vector2 position)
        {
            _spaceObject.transform.position = position;
            _spaceObject.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);

            return this;
        }

        public SpaceObjectBuilder SetRotation(Quaternion rotation)
        {
            _spaceObject.transform.rotation = rotation;

            return this;
        }

        public SpaceObjectBuilder SetRandomObjectView(Sprite[] sprites)
        {
            _spaceObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            
            return this;
        }

        public SpaceObject Build()
        {
            return _spaceObject;
        }
    }
}
