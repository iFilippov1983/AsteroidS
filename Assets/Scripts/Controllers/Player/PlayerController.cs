using System;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidS
{
    public sealed class PlayerController : IInitialization, IFixedExecute, IExecute, ILateExecute,  ICleanup
    {
        private  GameObject _playerObject;
        private readonly PlayerData _playerData;
        private readonly Rigidbody2D _playerRB;
        private readonly Transform _gunTransform;
        private readonly ShootingController _shooting;
        private readonly PlayerMover _mover;
        private readonly InputSystem _inputSystem;

        private List<ISoundEventSource> _soundEventSources;

        private readonly float _moveSpeed;
        private readonly float _rotationSpeed;

        public ShootingController ShootingController => _shooting;
        public Transform Player => _playerObject.transform;
        public PlayerController(PlayerData playerData)
        {
            _playerData = playerData;
            PlayerInstantiation(_playerData.PlayerPrefab);

            _shooting = new ShootingController(_playerData, _playerObject.transform);
            _mover = new PlayerMover();
            _inputSystem = new InputSystem();

            _playerRB = _playerObject.GetComponent<Rigidbody2D>();
            _gunTransform = _playerObject.transform.Find(TagOrName.Gun);

            _moveSpeed = _playerData.PlayerMovementSpeed;
            _rotationSpeed = _playerData.PlayerRotationSpeed;
        }

        public Action EscapePressed;

        public void Initialize()
        {
            _inputSystem.Initialize();
            _shooting.Initialize();

            _inputSystem.EscapePressed += HandleEscapeButton;
            _inputSystem.NumberButtonPressed += HandleNumberButtons;
        }

        public void FixedExecute()
        {
            HandleEscapeButton();

            _mover.Move(_inputSystem.Vertical, _playerRB, _moveSpeed);
            _mover.Rotate(_inputSystem.Horizontal, _playerRB, _rotationSpeed);
            _mover.Strafe(_inputSystem.Strafe, _playerRB, _moveSpeed);
            _mover.Aim(_inputSystem.AimAngle, _gunTransform);
            
            _shooting.HandlePrimaryShooting(_inputSystem.FirePrimary);
            _shooting.FixedExecute();
        }

        public void Execute(float deltatime)
        {
            _inputSystem.Execute();
            _shooting.Execute();
        }

        public void LateExecute()
        {
            _shooting.LateExecute();
        }

        public void Cleanup()
        {
            _inputSystem.Cleanup();
            _shooting.Cleanup();

            _inputSystem.EscapePressed -= HandleEscapeButton;
            _inputSystem.NumberButtonPressed -= HandleNumberButtons;
        }

        private void PlayerInstantiation(GameObject prefab)
        {
            _playerObject = UnityEngine.Object.Instantiate(prefab);
        }

        private void HandleEscapeButton()
        {
            if (_inputSystem.Cancel == 0) return;
            EscapePressed?.Invoke();
        }

        private void HandleNumberButtons(int number)
        {
            _playerData.SwitchAmmoTo(number);
        }
    }
}
