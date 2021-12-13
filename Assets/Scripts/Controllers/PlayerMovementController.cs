using UnityEngine;

namespace AsteroidS
{
    public class PlayerMovementController : IInitialization, IFixedExecute, ICleanup
    {
        private Rigidbody2D _rigidbodyToMove;
        private PlayerMovement _movement;
        private EscapeKeyHandler _escapeKeyHandler;

        private IUserInputProxy _horizontalMovement;
        private IUserInputProxy _verticalMovement;
        private IUserInputProxy _cancelInput;
        private float _horizontal;
        private float _vertical;
        private float _cancel;
        private float _moveSpeed;
        private float _rotationSpeed;


        public PlayerMovementController(
            GameData gameData,
            Transform player,
            (IUserInputProxy horizontalMovement, IUserInputProxy verticalMovement, IUserInputProxy cancel) input,
            GameStateController gameStateController)
        {
            _movement = new PlayerMovement();
            _escapeKeyHandler = new EscapeKeyHandler(gameStateController);
            _rigidbodyToMove = player.GetComponent<Rigidbody2D>();

            _horizontalMovement = input.horizontalMovement;
            _verticalMovement = input.verticalMovement;
            _cancelInput = input.cancel;

            _moveSpeed = gameData.PlayerData.PlayerMovementSpeed;
            _rotationSpeed = gameData.PlayerData.PlayerRotationSpeed;
        }

        public void Initialize()
        {
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
            _cancelInput.OnAxisChange += OnEscapePressed;
        }

        public void FixedExecute()
        {
            _movement.Move(_vertical, _rigidbodyToMove, _moveSpeed);
            _movement.Rotate(_horizontal, _rigidbodyToMove, _rotationSpeed);
            _escapeKeyHandler.EscapeKeyPressed(_cancel);
        }

        public void Cleanup()
        {
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
            _cancelInput.OnAxisChange -= OnEscapePressed;
        }

        private void OnVerticalAxisChange(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        private void OnEscapePressed(float value)
        {
            _cancel = value;
        }
    }
}
