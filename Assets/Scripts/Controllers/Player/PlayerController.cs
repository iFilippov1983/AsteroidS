using UnityEngine;

namespace AsteroidS
{
    public sealed class PlayerController : IInitialization, IFixedExecute, IExecute, ILateExecute,  ICleanup
    {
        private readonly Rigidbody2D _playerRB;
        private readonly Transform _gunTransform;
        private readonly ShootingController _shooting;
        private readonly PlayerMover _movement;
        private readonly KeysHandler _keysHandler;
#if UNITY_ANDROID
        private readonly AndroidPlayerUIController _androidPlayerUIController;
#endif
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

        private readonly float _moveSpeed;
        private readonly float _rotationSpeed;

        public PlayerController
            (
            GameData gameData,
            Transform player,
            InputInitializer inputInitializer,
            GameStateController gameStateController
#if UNITY_ANDROID
            , AndroidPlayerUIController androidPlayerUIController
#endif
            )
        {
            _shooting = new ShootingController(gameData, player);
            _movement = new PlayerMover();
            _keysHandler = new KeysHandler(gameData, gameStateController);
            _playerRB = player.GetComponent<Rigidbody2D>();
            _gunTransform = player.Find(TagOrName.Gun);
#if UNITY_STANDALONE
            _horizontalMovement = inputInitializer.GetInput().inputHorizontal;
            _verticalMovement = inputInitializer.GetInput().inputVertical;
            _primaryFire = inputInitializer.GetInput().inputPrimaryFire;
            _strafeMovement = inputInitializer.GetInput().inputStrafe;
            _switchInput = inputInitializer.GetInput().inputSwitch;
            _cancelInput = inputInitializer.GetInput().inputCancel;
            _numberInput = inputInitializer.GetInput().inputNumbers;
            _aimInput = inputInitializer.GetInput().inputAim;
#elif UNITY_ANDROID
            _androidPlayerUIController = androidPlayerUIController;
            _horizontalMovement = inputInitializer.GetInput().inputHorizontal;
            _verticalMovement = inputInitializer.GetInput().inputVertical;
            _primaryFire = inputInitializer.GetInput().inputPrimaryFire;
            _aimInput = inputInitializer.GetInput().inputAim;
#endif
            _moveSpeed = gameData.PlayerData.PlayerMovementSpeed;
            _rotationSpeed = gameData.PlayerData.PlayerRotationSpeed;
        }

        public ShootingController ShootingController => _shooting;

        public void Initialize()
        {
#if UNITY_STANDALONE
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
            _primaryFire.OnAxisChange += OnPrimaryShot;
            _strafeMovement.OnAxisChange += OnStrafeButtonsPressed;
            _switchInput.OnAxisChange += OnSwitchButtonPressed;
            _cancelInput.OnAxisChange += OnEscapePressed;
            _numberInput.OnAxisChange += OnNumberButtonPressed;
            _aimInput.OnAxisChange += OnAiming;
            _shooting.Initialize();
#elif UNITY_ANDROID
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
            _aimInput.OnAxisChange += OnAiming;
            _primaryFire.OnAxisChange += OnPrimaryShot;
            _androidPlayerUIController.OnAmmoSwitch += OnSwitchButtonPressed;
            _shooting.Initialize();
#endif
        }

        public void FixedExecute()
        {
            _movement.Move(_vertical, _playerRB, _moveSpeed);
            _movement.Rotate(_horizontal, _playerRB, _rotationSpeed);
            _movement.Strafe(_strafe, _playerRB, _moveSpeed);
            _movement.Aim(_aimAngle, _gunTransform);
            _keysHandler.SwitchKeyPressed(_switch);
            _keysHandler.EscapeKeyPressed(_cancel);
            _keysHandler.NubmerPressed(ref _numberButton);

            _shooting.HandlePrimaryShooting(_firePrimary);
            _shooting.FixedExecute();
        }

        public void Execute(float deltatime)
        {
            _shooting.Execute();
        }

        public void LateExecute()
        {
            _shooting.LateExecute();
        }

        public void Cleanup()
        {
#if UNITY_STANDALONE
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
            _primaryFire.OnAxisChange -= OnPrimaryShot;
            _strafeMovement.OnAxisChange -= OnStrafeButtonsPressed;
            _switchInput.OnAxisChange -= OnSwitchButtonPressed;
            _cancelInput.OnAxisChange -= OnEscapePressed;
            _numberInput.OnAxisChange -= OnNumberButtonPressed;
            _aimInput.OnAxisChange += OnAiming;
            _shooting.Cleanup();
#elif UNITY_ANDROID
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
            _aimInput.OnAxisChange += OnAiming;
            _primaryFire.OnAxisChange -= OnPrimaryShot;
            _androidPlayerUIController.OnAmmoSwitch -= OnSwitchButtonPressed;
            _shooting.Cleanup();
#endif
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
        }

        private void OnAiming(float value)
        {
            _aimAngle = value;
        }
    }
}
