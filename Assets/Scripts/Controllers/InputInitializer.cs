namespace AsteroidS
{
    public class InputInitializer
    {
        private InputStructure _pcInputStructure;

        public InputInitializer()
        {
            //if (Application.platform == RuntimePlatform.Android)
            //{
            //    _pcInputHorizontal = new MobileInput();
            //    return;
            //}

            _pcInputStructure.inputHorizontal = new PCInputHorizontal();
            _pcInputStructure.inputVertical = new PCInputVertical();
            _pcInputStructure.inputPrimaryFire = new PCInputPrimaryFire();
            _pcInputStructure.inputStrafe = new PCInputStrafe();
            _pcInputStructure.inputSwitch = new PCInputSwitch();
            _pcInputStructure.inputCancel = new PCInputCancel();
            _pcInputStructure.inputNumbers = new PCInputNumbers();
        }

        public InputStructure GetInput()
        {
            InputStructure result = _pcInputStructure;
            return result;
        }
    }
}
