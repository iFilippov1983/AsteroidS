﻿using System;
using UnityEngine;

namespace AsteroidS
{
    class CameraFollowController : IExecute
    {
        private const float _cameraZoomSpeed = 1f;
        private const float _cameraMoveSpeed = 1f;
        private Camera _camera;
        private Vector3 _cameraFollowPosition;
        private Vector3 _cameraMoveDirection;
        //private Vector3 _newCameraPosotion;
        //private float _distanceAfterMoving;
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
            //_cameraZoom = _camera.orthographicSize;
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

        public void Execute(float deltaTime)
        {
            HandleZoom(deltaTime);
            HandleMovement(deltaTime);
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

            //if (_distance > 0)
            //{
            //    _newCameraPosotion = _camera.transform.position + _cameraMoveDirection * _distance * _cameraMoveSpeed * deltaTime;

            //    _distanceAfterMoving = Vector3.Distance(_newCameraPosotion, _cameraFollowPosition);

            //    if (_distanceAfterMoving > _distance)
            //    {
            //        _cameraFollowPosition.z = -10f;
            //        _newCameraPosotion = _cameraFollowPosition;
            //    } 
            //}

            //_camera.transform.position = _newCameraPosotion;
        }
    }
}
