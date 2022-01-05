using System;
using UnityEngine;

namespace AsteroidS
{
    class PCInputMouseY : IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate { };

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(InputName.Mouse_Y));
        }
    }
}
