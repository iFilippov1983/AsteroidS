using UnityEngine;

namespace AsteroidS
{
    public class PlayerController : IInitialization, IFixedExecute, ICleanup
    {
        private Rigidbody2D _rigidbodyToMove;
        private PlayerMovement _movement;
        private KeysHandler _keysHandler;

        private IUserInputProxy _horizontalMovement;
        private IUserInputProxy _verticalMovement;
        private IUserInputProxy _strafeMovement;
        private IUserInputProxy _switchInput;
        private IUserInputProxy _cancelInput;
        private IUserInputProxy _numberInput;

        private float _horizontal;
        private float _vertical;
        private float _strafe;
        private float _switch;
        private float _cancel;
        private int _numberButton;

        private float _moveSpeed;
        private float _rotationSpeed;

        public PlayerController(
            GameData gameData,
            Transform player,
            InputInitializer inputInitializer,
            GameStateController gameStateController)
        {
            _movement = new PlayerMovement();
            _keysHandler = new KeysHandler(gameData, gameStateController);
            _rigidbodyToMove = player.GetComponent<Rigidbody2D>();

            _horizontalMovement = inputInitializer.GetInput().inputHorizontal;
            _verticalMovement = inputInitializer.GetInput().inputVertical;
            _strafeMovement = inputInitializer.GetInput().inputStrafe;
            _switchInput = inputInitializer.GetInput().inputSwitch;
            _cancelInput = inputInitializer.GetInput().inputCancel;
            _numberInput = inputInitializer.GetInput().inputNumbers;

            _moveSpeed = gameData.PlayerData.PlayerMovementSpeed;
            _rotationSpeed = gameData.PlayerData.PlayerRotationSpeed;
        }

        public void Initialize()
        {
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
            _strafeMovement.OnAxisChange += OnStrafeButtonsPressed;
            _switchInput.OnAxisChange += OnSwitchButtonPressed;
            _cancelInput.OnAxisChange += OnEscapePressed;
            _numberInput.OnAxisChange += OnNumberButtonPressed;
        }

        public void FixedExecute()
        {
            _movement.Move(_vertical, _rigidbodyToMove, _moveSpeed);
            _movement.Rotate(_horizontal, _rigidbodyToMove, _rotationSpeed);
            _movement.Strafe(_strafe, _rigidbodyToMove, _moveSpeed);
            _keysHandler.SwitchKeyPressed(_switch);
            _keysHandler.EscapeKeyPressed(_cancel);
            _keysHandler.NubmerPressed(ref _numberButton);
        }

        public void Cleanup()
        {
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
            _strafeMovement.OnAxisChange -= OnStrafeButtonsPressed;
            _switchInput.OnAxisChange -= OnSwitchButtonPressed;
            _cancelInput.OnAxisChange -= OnEscapePressed;
            _numberInput.OnAxisChange -= OnNumberButtonPressed;
        }

        private void OnVerticalAxisChange(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
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
        }
    }
}
