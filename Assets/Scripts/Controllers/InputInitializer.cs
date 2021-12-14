using UnityEngine;

namespace AsteroidS
{
    public class InputInitializer
    {
        public IUserInputProxy _pcInputHorizontal;
        public IUserInputProxy _pcInputVertical;
        public IUserInputProxy _pcInputStrafe;
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
            _pcInputStrafe = new PCInputStrafe();
            _pcInputCancel = new PCInputCancel();
        }

        public (
            IUserInputProxy inputHorizontal, 
            IUserInputProxy inputVertical,
            IUserInputProxy inputStrafe,
            IUserInputProxy inputCancel
                )GetInput()
        {
            (
                IUserInputProxy inputHorizontal, 
                IUserInputProxy inputVertical,
                IUserInputProxy inpetStrafe,
                IUserInputProxy inputCancel
            ) 
            result = 
            (
                _pcInputHorizontal, 
                _pcInputVertical,
                _pcInputStrafe,
                _pcInputCancel
            );

            return result;
        }
    }
}
