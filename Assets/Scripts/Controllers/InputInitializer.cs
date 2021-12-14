using UnityEngine;

namespace AsteroidS
{
    public class InputInitializer
    {
        public IUserInputProxy _pcInputHorizontal;
        public IUserInputProxy _pcInputVertical;
        public IUserInputProxy _pcInputCancel;

        public InputInitializer()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _pcInputHorizontal = new MobileInput();
                return;
            }
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _pcInputCancel = new PCInputCancel();
        }

        public (
            IUserInputProxy inputHorizontal, 
            IUserInputProxy inputVertical, 
            IUserInputProxy inputCancel) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inpurVertical, IUserInputProxy inputCancel) result =
                (_pcInputHorizontal, _pcInputVertical, _pcInputCancel);

            return result;
        }
    }
}
