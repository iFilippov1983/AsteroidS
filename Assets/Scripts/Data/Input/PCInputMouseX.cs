using System;
using UnityEngine;

namespace AsteroidS
{
    class PCInputMouseX : IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate { };

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(InputName.Mouse_X));
        }
    }
}
