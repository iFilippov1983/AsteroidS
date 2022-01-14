using UnityEngine;

namespace AsteroidS
{
    public sealed class SpaceObjectDriver
    {
        public void Drive(SpaceObject spaceObject)
        {
            spaceObject.gameObject.SetActive(true);

            var rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            var speed = spaceObject.Properties.speed;

            var direction = spaceObject.transform.rotation * (Camera.main.transform.position - spaceObject.transform.position);
            rb.AddForce(direction.normalized * speed);
        }

        public void Redrive(SpaceObject spaceObject, Vector2 direction)
        {
            spaceObject.gameObject.SetActive(true);

            var rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            var speed = spaceObject.Properties.speed;

            rb.AddForce(direction.normalized * speed);
        }

        public void Stop(SpaceObject spaceObject)
        {
            spaceObject.gameObject.SetActive(false);
            spaceObject.transform.position = Vector3.zero;
            spaceObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
