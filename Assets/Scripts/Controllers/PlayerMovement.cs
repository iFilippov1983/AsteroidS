using UnityEngine;

namespace AsteroidS
{
    public class PlayerMovement
    {
        private float _direction;

        public void Move(float normal, Rigidbody2D rigidbodyToMove, float moveSpeed)
        {
            if (normal > 0)
            {
                Vector2 vectorUP = rigidbodyToMove.transform.up * moveSpeed;
                rigidbodyToMove.AddForce(vectorUP);
            }
            if (normal < 0)
            {
                Vector2 vectorDOWN = -rigidbodyToMove.transform.up * moveSpeed;
                rigidbodyToMove.AddForce(vectorDOWN);
            }
        }

        public void Rotate(float normal, Rigidbody2D rigidbodyToRotate, float rotationSpeed)
        {
            if (normal > 0) _direction = -1f;
            else if (normal < 0) _direction = 1f;
            else _direction = 0f;

            if (rigidbodyToRotate && _direction != 0)
            {
                rigidbodyToRotate.AddTorque(_direction * rotationSpeed);
            }
        }

        public void Starfe(float normal, Rigidbody2D rigidbodyToStrafe, float moveSpeed)
        {
            if (normal > 0)
            {
                Vector2 vectorRIGHT = rigidbodyToStrafe.transform.right * moveSpeed;
                rigidbodyToStrafe.AddForce(vectorRIGHT);
            }
            if (normal < 0)
            {
                Vector2 vectorLEFT = -rigidbodyToStrafe.transform.right * moveSpeed;
                rigidbodyToStrafe.AddForce(vectorLEFT);
            }
        }
    }
}
