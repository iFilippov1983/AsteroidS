using UnityEngine;

namespace AsteroidS
{
    public sealed class AmmoDriver
    {
        public void Drive(Ammo ammo, Transform transform)
        {
            ammo.gameObject.SetActive(true);
            ammo.transform.position = transform.position;
            ammo.transform.rotation = transform.rotation;

            var rb = ammo.gameObject.GetComponent<Rigidbody2D>();
            var speed = ammo.Properties.SpeedRate;
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }

        public void Stop(Ammo ammo)
        {
            ammo.gameObject.SetActive(false);
            ammo.transform.position = Vector3.zero;
            ammo.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}

