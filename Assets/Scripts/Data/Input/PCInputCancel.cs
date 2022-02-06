using System;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PCInputCancel:IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate(float f) {  };
        public void GetAxis()
        {
            OnAxisChange?.Invoke(Input.GetAxis(InputName.Cancel));
        }
    }
}