using System;

namespace AsteroidS
{
    public class AndroidMovementInputVertical:IUserInputProxy
    {
        public event Action<float> OnAxisChange;
            public void GetAxis()
            {
                OnAxisChange?.Invoke(MovementJoystick.GetAxis(InputName.Horizontal));
            }
    }
}