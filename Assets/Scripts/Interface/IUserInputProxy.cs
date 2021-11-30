using System;

namespace AsteroidS
{
    public interface IUserInputProxy
    {
        event Action<float> OnAxisChange;
        void GetAxis();
    }
}
