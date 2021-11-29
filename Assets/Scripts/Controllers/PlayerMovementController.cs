using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AsteroidS
{
    class PlayerMovementController : IInitialization, IFixedExecute, ICleanup
    {
        private Rigidbody2D _rigidbodyToMove;
        private Movement _movement;

        private IUserInputProxy _horizontalMovement;
        private IUserInputProxy _verticalMovement;
        private float _horizontal;
        private float _vertical;
        private float _moveSpeed;
        private float _rotationSpeed;


        public PlayerMovementController(
            GameData gameData,
            Transform player,
            (IUserInputProxy horizontalMovement, IUserInputProxy verticalMovement) input)
        {
            _movement = new Movement();
            _rigidbodyToMove = player.GetComponent<Rigidbody2D>();

            _horizontalMovement = input.horizontalMovement;
            _verticalMovement = input.verticalMovement;

            _moveSpeed = gameData.PlayerData.PlayerMovementSpeed;
            _rotationSpeed = gameData.PlayerData.PlayerRotationSpeed;
        }

        public void Initialize()
        {
            _horizontalMovement.OnAxisChange += OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange += OnVerticalAxisChange;
        }

        public void FixedExecute()
        {
            _movement.Move(_vertical, _rigidbodyToMove, _moveSpeed);
            _movement.Rotate(_horizontal, _rigidbodyToMove, _rotationSpeed);
        }

        public void Cleanup()
        {
            _horizontalMovement.OnAxisChange -= OnHorizontalAxisChange;
            _verticalMovement.OnAxisChange -= OnVerticalAxisChange;
        }

        private void OnVerticalAxisChange(float value)
        {
            _vertical = value;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value;
        }

        
    }
}
