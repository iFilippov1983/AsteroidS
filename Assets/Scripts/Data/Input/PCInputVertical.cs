using System;
using UnityEngine;

namespace AsteroidS
{
    class PCInputVertical : IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate { };

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(AxisManager.Vertical));
        }
    }
}