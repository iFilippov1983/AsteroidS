using System;
using UnityEngine;

namespace AsteroidS
{
    public sealed class CameraFollowController : IFixedExecute
    {
        private const float _cameraZoomSpeed = 1f;
        private const float _cameraMoveSpeed = 1f;
        private Camera _camera;
        private Vector3 _cameraFollowPosition;
        private Vector3 _cameraMoveDirection;
        private float _distance;
        private float _cameraZoom;
        private float _cameraZoomDifference;

        private Func<Vector3> GetCameraFollowPositionFunc;
        private Func<float> GetCameraZoomFunc;

        public void Setup(Func<Vector3> CameraFollowPositionFunc, Func<float> CameraZoomFunc, Camera camera)
        {
            GetCameraFollowPositionFunc = CameraFollowPositionFunc;
            GetCameraZoomFunc = CameraZoomFunc;
            _camera = camera;
        }

        //TODO: use!!!
        public void SetCameraFollowPosition(Vector3 cameraFollowPosition)
        {
            SetFollowFunc(() => cameraFollowPosition);
        }

        public void SetFollowFunc(Func<Vector3> CameraFollowPositionFunc)
        {
            GetCameraFollowPositionFunc = CameraFollowPositionFunc;
        }

        //TODO: use!!!
        public void SetCameraZoom(float cameraZoom)
        {
            SetZoomFunc(() => cameraZoom);
        }

        public void SetZoomFunc(Func<float> CameraZoomFunc)
        {
            GetCameraZoomFunc = CameraZoomFunc;
        }

        public void FixedExecute()
        {
            HandleZoom(Time.fixedDeltaTime);
            HandleMovement(Time.fixedDeltaTime);
        }

        private void HandleZoom(float deltaTime)
        {
            _cameraZoom = GetCameraZoomFunc();
            _cameraZoomDifference = _cameraZoom - _camera.orthographicSize;
            _camera.orthographicSize += _cameraZoomDifference * _cameraZoomSpeed * deltaTime;

            if (_cameraZoomDifference > 0)
            {
                if (_camera.orthographicSize > _cameraZoom) _camera.orthographicSize = _cameraZoom;
            }
            else
            {
                if (_camera.orthographicSize < _cameraZoom) _camera.orthographicSize = _cameraZoom;
            }
        }

        private void HandleMovement(float deltaTime)
        {
            _cameraFollowPosition = GetCameraFollowPositionFunc();
            _cameraFollowPosition.z = _camera.transform.position.z;

            _cameraMoveDirection = (_cameraFollowPosition - _camera.transform.position).normalized;
            _distance = Vector3.Distance(_cameraFollowPosition, _camera.transform.position);

            _camera.transform.position += _cameraMoveDirection * _distance * _cameraMoveSpeed * deltaTime;
        }
    }
}
