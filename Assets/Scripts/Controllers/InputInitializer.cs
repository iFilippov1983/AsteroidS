using UnityEngine;

namespace AsteroidS
{
    public class InputInitializer
    {
        public IUserInputProxy _pcInputHorizontal;
        public IUserInputProxy _pcInputVertical;

        public InputInitializer()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _pcInputHorizontal = new MobileInput();
                return;
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inpurVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inpurVertical) result =
                (_pcInputHorizontal, _pcInputVertical);

            return result;
        }
    }
}
