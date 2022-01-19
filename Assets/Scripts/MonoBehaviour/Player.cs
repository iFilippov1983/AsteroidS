using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtilities;


namespace AsteroidS
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private FieldOfView _fov;
        private Transform _gun;

        void Start()
        {
            _gun = gameObject.transform.Find(TagOrName.Gun);
            _fov = FindObjectOfType<FieldOfView>();
        }

        void Update()
        {
            Vector3 position = Utilities.GetMouseWorldPosition();
            Vector3 aimDir = (position - transform.position).normalized;

            _fov.SetAimDerection(aimDir);
            _fov.SetOrigin(_gun.position);
        }
    }

}
