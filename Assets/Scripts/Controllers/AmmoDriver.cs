using UnityEngine;

namespace AsteroidS
{
    public class AmmoDriver
    {
        public void Drive(Ammo ammo, Vector3 forceVector)
        {
            ammo.gameObject.SetActive(true);

            var rb = ammo.gameObject.GetComponent<Rigidbody2D>();
            var speed = ammo.Properties.speedRate;
            rb.AddForce(forceVector * speed);
        }

        public void Stop(Ammo ammo)
        {
            ammo.gameObject.SetActive(false);
            ammo.transform.position = Vector3.zero;
            ammo.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}

