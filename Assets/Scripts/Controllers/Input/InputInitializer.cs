namespace AsteroidS
{
    public sealed class InputInitializer
    {
        private InputStructure _inputStructure;

        public InputInitializer()
        {
            _inputStructure.inputHorizontal = new PCInputHorizontal();
            _inputStructure.inputVertical = new PCInputVertical();
            _inputStructure.inputPrimaryFire = new PCInputPrimaryFire();
            _inputStructure.inputStrafe = new PCInputStrafe();
            _inputStructure.inputSwitch = new PCInputSwitch();
            _inputStructure.inputCancel = new PCInputCancel();
            _inputStructure.inputNumbers = new PCInputNumbers();
            _inputStructure.inputAim = new PCInputAim();
        }

        public InputStructure GetInput()
        {
            InputStructure result = _inputStructure;
            return result;
        }
    }
}
