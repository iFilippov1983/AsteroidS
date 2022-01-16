namespace AsteroidS
{
    public sealed class InputInitializer
    {
        private readonly InputStructure _inputStructure;

        public InputInitializer(UIComponentInitializer uiComponentInitializer)
        {
#if UNITY_STANDALONE
            _inputStructure.inputHorizontal = new PCInputHorizontal();
            _inputStructure.inputVertical = new PCInputVertical();
            _inputStructure.inputPrimaryFire = new PCInputPrimaryFire();
            _inputStructure.inputStrafe = new PCInputStrafe();
            _inputStructure.inputSwitch = new PCInputSwitch();
            _inputStructure.inputCancel = new PCInputCancel();
            _inputStructure.inputNumbers = new PCInputNumbers();
            _inputStructure.inputAim = new PCInputAim();
#elif UNITY_ANDROID
            var androidInputProxy = new AndroidInputProxy(uiComponentInitializer);
            _inputStructure.inputHorizontal = androidInputProxy.AndroidMovementInputHorizontal;
            _inputStructure.inputVertical = androidInputProxy.AndroidMovementInputVertical;
            _inputStructure.inputAim = androidInputProxy.AndroidInputAim;
            _inputStructure.inputPrimaryFire = androidInputProxy.AndroidFireInput;
#endif
        }

        public InputStructure GetInput()
        {
            InputStructure result = _inputStructure;
            return result;
        }
    }
}
