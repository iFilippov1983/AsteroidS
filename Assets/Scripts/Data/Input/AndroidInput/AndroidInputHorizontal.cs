using System;

namespace AsteroidS
{
    public sealed class AndroidInputHorizontal: IUserInputProxy
    {
        private FloatingJoystick _joystick;
        public event Action<float> OnAxisChange;

        public AndroidInputHorizontal(FloatingJoystick joystick)
        {
            _joystick = joystick;
        }

        public void GetAxis()
        {
            OnAxisChange?.Invoke(_joystick.GetHorizontal());
        }
    }
}