using UnityEngine;

namespace AsteroidS
{
    public class SpaceObjectBuilder
    {
        private SpaceObject _spaceObject;

        public SpaceObjectBuilder MakeInstance(SpaceObject prefab)
        {
            _spaceObject = Object.Instantiate(prefab);

            return this;
        }

        public SpaceObjectBuilder SetPosition(Vector2 position)
        {
            _spaceObject.transform.position = position;

            return this;
        }

        public SpaceObjectBuilder SetObjectView(Sprite[] sprites)
        {
            _spaceObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            
            return this;
        }

        public SpaceObjectBuilder SetRandomRotation()
        {
            _spaceObject.transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360.0f);

            return this;
        }

        public SpaceObject Get()
        {
            return _spaceObject;
        }
    }
}
