using System;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PCInputSwitch : IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate { };

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(InputName.Switch));
        }
    }
}
