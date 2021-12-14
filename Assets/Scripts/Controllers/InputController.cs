namespace AsteroidS
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _cancel;

        public InputController(InputInitializer inputInitializer)
        {
            _horizontal = inputInitializer.GetInput().inputHorizontal;
            _vertical = inputInitializer.GetInput().inputVertical;
            _cancel = inputInitializer.GetInput().inputCancel;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _cancel.GetAxis();
        }
    }
}
