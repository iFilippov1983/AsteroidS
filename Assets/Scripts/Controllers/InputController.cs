namespace AsteroidS
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _strafe;
        private readonly IUserInputProxy _switch;
        private readonly IUserInputProxy _cancel;
        private readonly IUserInputProxy _numberPressed;

        public InputController(InputInitializer inputInitializer)
        {
            _horizontal = inputInitializer.GetInput().inputHorizontal;
            _vertical = inputInitializer.GetInput().inputVertical;
            _strafe = inputInitializer.GetInput().inputStrafe;
            _switch = inputInitializer.GetInput().inputSwitch;
            _cancel = inputInitializer.GetInput().inputCancel;
            _numberPressed = inputInitializer.GetInput().inputNumbers;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _strafe.GetAxis();
            _switch.GetAxis();
            _cancel.GetAxis();
            _numberPressed.GetAxis();
        }
    }
}
