using UnityEngine;

namespace AsteroidS
{
    public class SpaceObject : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private string _spaceObjectPropertiesPath;

        private SpaceObjectProperties _properties;

        public Collider2D Collider => GetComponent<Collider2D>();
        public Rigidbody2D Rigidbody => GetComponent<Rigidbody2D>();

        public Sprite[] GetSprites => _sprites;

        public SpaceObjectProperties GetSpaceObjectProperties
        {
            get 
            {
                if (_properties == null)
                {
                    _properties = Resources.Load<SpaceObjectProperties>("GameData/" + _spaceObjectPropertiesPath);
                }

                return _properties;
            }
        }
    }
}
