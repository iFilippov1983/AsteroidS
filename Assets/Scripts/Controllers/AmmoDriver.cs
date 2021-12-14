using UnityEngine;

namespace AsteroidS
{
    public class AmmoDriver
    {
        public void Drive(Ammo ammo, Transform transform)
        {
            ammo.gameObject.SetActive(true);
            ammo.transform.position = transform.position;
            ammo.transform.rotation = transform.rotation;

            var rb = ammo.gameObject.GetComponent<Rigidbody2D>();
            var speed = ammo.Properties.speedRate;
            rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }

        public void Stop(Ammo ammo)
        {
            //temp
            Debug.Log($"Stop: {Time.time}");

            ammo.gameObject.SetActive(false);

            //temp
            Debug.Log($"{ammo.gameObject.active}: {Time.time}");

            ammo.transform.position = Vector3.zero;
            ammo.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}

