using UnityEngine;

namespace AsteroidS
{
    public sealed class ParallaxBackgroundController : IInitialization, ILateExecute
    {
        private Transform _cameraTransform;
        private Vector3 _lastCameraPosition;
        private Vector3 _deltaMovement;
        private Transform _parallaxBGTransform;
        private Vector2 _parallaxEffectMultiplier;
        private float _textureUnitSizeX;
        private float _textureUnitSizeY;

        public ParallaxBackgroundController(Transform parallaxImageTransform, Vector2 multiplier)
        {
            _parallaxBGTransform = parallaxImageTransform;
            _parallaxEffectMultiplier = multiplier;
        }

        public void Initialize()
        {
            _cameraTransform = Camera.main.transform;
            _lastCameraPosition = _cameraTransform.position;
            Sprite sprite = _parallaxBGTransform.GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            _textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        }

        public void LateExecute()
        {
            _deltaMovement = _cameraTransform.position - _lastCameraPosition;
            _parallaxBGTransform.position += new Vector3(
                _deltaMovement.x * _parallaxEffectMultiplier.x,
                _deltaMovement.y * _parallaxEffectMultiplier.y);
            _lastCameraPosition = _cameraTransform.position;

            if (Mathf.Abs(_cameraTransform.position.x - _parallaxBGTransform.position.x) >= _textureUnitSizeX)
            {
                float offsetPositionX = 
                    (_cameraTransform.position.x - _parallaxBGTransform.position.x) % _textureUnitSizeX;
                _parallaxBGTransform.position =
                    new Vector3(_cameraTransform.position.x + offsetPositionX,
                                _parallaxBGTransform.position.y);
            }

            if (Mathf.Abs(_cameraTransform.position.y - _parallaxBGTransform.position.y) >= _textureUnitSizeY)
            {
                float offsetPositionY =
                    (_cameraTransform.position.y - _parallaxBGTransform.position.y) % _textureUnitSizeY;
                _parallaxBGTransform.position =
                    new Vector3(_parallaxBGTransform.position.x, _cameraTransform.position.y + offsetPositionY);
            }
        }
    }
}
