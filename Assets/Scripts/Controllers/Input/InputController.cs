namespace AsteroidS
{
    public sealed class InputController
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _primaryFire;
        private readonly IUserInputProxy _strafe;
        private readonly IUserInputProxy _switch;
        private readonly IUserInputProxy _cancel;
        private readonly IUserInputProxy _numberPressed;
        private readonly IUserInputProxy _aim;

        public InputController(InputInitializer inputInitializer)
        {
            _horizontal = inputInitializer.GetInput().inputHorizontal;
            _vertical = inputInitializer.GetInput().inputVertical;
            _primaryFire = inputInitializer.GetInput().inputPrimaryFire;
            _strafe = inputInitializer.GetInput().inputStrafe;
            _switch = inputInitializer.GetInput().inputSwitch;
            _cancel = inputInitializer.GetInput().inputCancel;
            _numberPressed = inputInitializer.GetInput().inputNumbers;
            _aim = inputInitializer.GetInput().inputAim;
        }
        
        public void Execute()
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _primaryFire.GetAxis();
            _strafe.GetAxis();
            _switch.GetAxis();
            _cancel.GetAxis();
            _numberPressed.GetAxis();
            _aim.GetAxis();
        }
    }
}
