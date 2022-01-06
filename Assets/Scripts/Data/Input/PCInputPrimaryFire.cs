using System;
using UnityEngine;

namespace AsteroidS
{
    class PCInputPrimaryFire : IUserInputProxy
    {
        public event Action<float> OnAxisChange;

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(InputName.PrimaryFire));
        }
    }
}
