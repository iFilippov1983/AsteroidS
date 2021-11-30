using UnityEngine;

namespace AsteroidS
{
    class AsteroidBig : Asteroid
    {
        [SerializeField] private Sprite[] _sprites;

        
        public Collider2D Collider => GetComponent<Collider2D>();
        public Rigidbody2D Rigidbody => GetComponent<Rigidbody2D>();

        public override Sprite[] GetSprites() => _sprites;

        public override AsteroidProperties GetAsteroidProperties() => 
            new AsteroidProperties
        {
            type = AsteroidType.Big,
            hitPoints = 100,
            mass = 10,
            speed = 10f,
            amountOnScene = 10,
            breakable = true
        };
    }
}
