using UnityEngine;

namespace AsteroidS
{
    public class InputInitializer
    {
        public IUserInputProxy _pcInputHorizontal;
        public IUserInputProxy _pcInputVertical;
        public IUserInputProxy _pcInputStrafe;
        public IUserInputProxy _pcInputSwitch;
        public IUserInputProxy _pcInputCancel;
        public IUserInputProxy _pcInputNumbers;

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
            _pcInputSwitch = new PCInputSwitch();
            _pcInputCancel = new PCInputCancel();
            _pcInputNumbers = new PCInputNumbers();
        }

        public (
            IUserInputProxy inputHorizontal, 
            IUserInputProxy inputVertical,
            IUserInputProxy inputStrafe,
            IUserInputProxy inputSwitch,
            IUserInputProxy inputCancel,
            IUserInputProxy inputNumbers
                )GetInput()
        {
            (
                IUserInputProxy inputHorizontal, 
                IUserInputProxy inputVertical,
                IUserInputProxy inpetStrafe,
                IUserInputProxy inputSwitch,
                IUserInputProxy inputCancel,
                IUserInputProxy inputNumbers
            ) 
            result = 
            (
                _pcInputHorizontal, 
                _pcInputVertical,
                _pcInputStrafe,
                _pcInputSwitch,
                _pcInputCancel,
                _pcInputNumbers
            );

            return result;
        }
    }
}
