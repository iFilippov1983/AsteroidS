using System;

namespace AsteroidS
{
    interface IUserInputProxy
    {
        event Action<float> OnAxisChange;
        void GetAxis();
    }
}
