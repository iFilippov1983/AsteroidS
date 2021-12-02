using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    class SpaceObjectDriver
    {
        public void Drive(SpaceObject spaceObject)
        {
            spaceObject.gameObject.SetActive(true);

            var rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            var speed = spaceObject.GetSpaceObjectProperties.speed;
            rb.AddForce(SetTrajectory(spaceObject) * speed);
        }

        public void Stop(SpaceObject spaceObject)
        {
            spaceObject.gameObject.SetActive(false);
            spaceObject.transform.position = Vector2.zero;

            var rb = spaceObject.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }

        private Vector3 SetTrajectory(SpaceObject obj)
        {
            var trajectory = obj.transform.rotation * -(obj.transform.position - Vector3.zero);
            return trajectory;
        }
    }
}
