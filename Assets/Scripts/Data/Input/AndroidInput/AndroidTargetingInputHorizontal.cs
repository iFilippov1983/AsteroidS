using System;

namespace AsteroidS
{
    public class AndroidTargetingInputHorizontal: IUserInputProxy
    {
        public event Action<float> OnAxisChange;
        public void GetAxis()
        {
            OnAxisChange?.Invoke(TargetJoystick.GetAxis(InputName.Horizontal));
        }
    }
}