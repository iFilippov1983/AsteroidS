using System;

namespace AsteroidS
{
    public class AndroidTargetingInputVertical: IUserInputProxy
    {
        public event Action<float> OnAxisChange;
        public void GetAxis()
        {
            OnAxisChange?.Invoke(TargetJoystick.GetAxis(InputName.Vertical));
        }
    }
}