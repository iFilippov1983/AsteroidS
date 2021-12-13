namespace AsteroidS
{
    public class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputProxy _cancel;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputProxy inputCancel) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _cancel = input.inputCancel;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _cancel.GetAxis();
        }
    }
}
