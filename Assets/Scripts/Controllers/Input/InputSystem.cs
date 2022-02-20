using System;

namespace AsteroidS 
{
    public sealed class InputSystem 
    {
        private InputInitializer _inputInitializer;
        private InputController _inputController;

        private IUserInputProxy _horizontalMovement;
        private IUserInputProxy _verticalMovement;
        private IUserInputProxy _primaryFire;
        private IUserInputProxy _strafeMovement;
        private IUserInputProxy _switchInput;
        private IUserInputProxy _cancelInput;
        private IUserInputProxy _numberInput;
        private IUserInputProxy _aimInput;

        private float _horizontal;
        private float _vertical;
        private float _firePrimary;
        private float _strafe;
        private float _switch;
        private float _cancel;
        private int _numberButton;
        private float _aimAngle;

        public float Horizontal => _horizontal;
        public float Vertical => _vertical;
        public float FirePrimary => _firePrimary;
        public float Strafe => _strafe;
        public float Switch => _switch;
        public float Cancel => _cancel;
        public int NumberButton => _numberButton;
        public float AimAngle => _aimAngle;

        public InputInitializer InputInitializer => _inputInitializer;

        public InputSystem()
        {
            _inputInitializer = new InputInitializer();
            _inputController = new InputController(_inputInitializer);

            _horizontalMovement = _inputInitializer.GetInput().inputHorizontal;
            _verticalMovement = _inputInitializer.GetInput().inputVertical;
            _primaryFire = _inputInitializer.GetInput().inputPrimaryFire;
            _strafeMovement = _inputInitializer.GetInput().inputStrafe;
            _switchInput = _inputInitializer.GetInput().inputSwitch;
            _cancelInput = _inputInitializer.GetInput().inputCancel;
            _numberInput = _inputInitializer.GetInput().inputNumbers;
            _aimInput = _inputInitializer.GetInput().inputAim;
        }

        public Action EscapePressed;
        public Action<int> NumberButtonPressed;

        public void Initialize()
        {
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
            _primaryFire.OnAxisChange += OnPrimaryShot;
            _strafeMovement.OnAxisChange += OnStrafeButtonsPressed;
            _switchInput.OnAxisChange += OnSwitchButtonPressed;
            _cancelInput.OnAxisChange += OnEscapePressed;
            _numberInput.OnAxisChange += OnNumberButtonPressed;
            _aimInput.OnAxisChange += OnAiming;
        }

        public void Execute()
        {
            _inputController.Execute();
        }

        public void Cleanup()
        {
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
            _primaryFire.OnAxisChange -= OnPrimaryShot;
            _strafeMovement.OnAxisChange -= OnStrafeButtonsPressed;
            _switchInput.OnAxisChange -= OnSwitchButtonPressed;
            _cancelInput.OnAxisChange -= OnEscapePressed;
            _numberInput.OnAxisChange -= OnNumberButtonPressed;
            _aimInput.OnAxisChange -= OnAiming;
        }

        public void HandleEscapeButton()
        {
            if (_cancel == 0) return;
            EscapePressed?.Invoke();
        }

        private void OnVerticalAxisChange(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        private void OnPrimaryShot(float value)
        {
            _firePrimary = value;
        }

        private void OnStrafeButtonsPressed(float value)
        {
            _strafe = value;
        }

        private void OnEscapePressed(float value)
        {
            _cancel = value;
        }

        private void OnSwitchButtonPressed(float value)
        {
            _switch = value;
        }

        private void OnNumberButtonPressed(float value)
        {
            _numberButton = (int)value;
            NumberButtonPressed?.Invoke(_numberButton);
        }

        private void OnAiming(float value)
        {
            _aimAngle = value;
        }
    }
}