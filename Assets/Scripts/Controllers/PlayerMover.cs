using UnityEngine;

namespace AsteroidS
{
    public class PlayerMover
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

        public void Strafe(float normal, Rigidbody2D rigidbodyToStrafe, float moveSpeed)
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

        public void Aim(Transform gunTransform)
        {
            Vector3 mousePosition = GetMouseWorldPosition();

            Vector3 aimDirection = (mousePosition - gunTransform.position).normalized;
            float angle = -Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
            gunTransform.eulerAngles = new Vector3(0, 0, angle);
        }

        //Get mouse position in World with Z = 0f
        private Vector3 GetMouseWorldPosition()
        {
            Vector3 vector = GetMoseWorldPositionV3(Input.mousePosition, Camera.main);
            vector.z = 0f;
            return vector;
        }

        private Vector3 GetMoseWorldPositionV3(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }
    }
}
