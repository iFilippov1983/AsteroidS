using UnityEngine;

namespace AsteroidS
{
    public class SpaceObjectDriver
    {
        public void Drive(SpaceObject spaceObject)
        {
            spaceObject.gameObject.SetActive(true);

            var rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            var speed = spaceObject.Properties.speed;
            if (spaceObject.Properties.isChild) speed *= spaceObject.Properties.ChildSpeedMiltiplyer;

            rb.AddForce(SetTrajectory(spaceObject) * speed);
        }

        public void Stop(SpaceObject spaceObject)
        {
            if (spaceObject.Properties.isChild) spaceObject.Properties.isChild = false;
            
            spaceObject.gameObject.SetActive(false);
            spaceObject.transform.position = Vector2.zero;
            spaceObject.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        private Vector3 SetTrajectory(SpaceObject obj)
        {
            var trajectory = obj.transform.rotation * -(obj.transform.position - Vector3.zero);
            return trajectory;
        }
    }
}
