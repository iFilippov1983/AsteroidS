using UnityEngine;
using CustomUtilities;

namespace AsteroidS
{
    public class FieldOfViewHandler 
    {
        private LayerMask _layerMask = 0;
        private int _rayCount = 50;

        private float _fov;
        private float _viewDistance;
        private Mesh _mesh;
        public Vector3 _origin;
        public float _startingAngle;
        private float _angleIncrease;

        public FieldOfViewHandler(MeshFilter filter, float viewDistance, float viewAngle)
        {
            _mesh = new Mesh();
            filter.mesh = _mesh;
            _fov = viewAngle;
            _viewDistance = viewDistance;
            _origin = Vector3.zero;
            _angleIncrease = _fov / _rayCount;
        }

        public void ReInitialize(MeshFilter filter, float viewDistance, float viewAngle)
        {
            _mesh = new Mesh(); 
            filter.mesh = _mesh;
            _fov = viewAngle;
            _viewDistance = viewDistance;
            _angleIncrease = _fov / _rayCount;
        }

        /// <summary>
        /// Call this method in LateUpdate
        /// </summary>
        public void LateExecute()
        {
            CalculateMesh();
        }

        public void SetOrigin(Vector3 origin)
        {
            _origin = origin;
        }

        public void SetAimDerection(Vector3 direction)
        {
            _startingAngle = Utilities.GetAngleFromVectorFloat(direction) + _fov / 2;
        }

        public void SetFoV(float fov)
        {
            _fov = fov;
        }

        public void SetViewDistance(float distance)
        {
            _viewDistance = distance;
        }

        public void SetLayerMask(LayerMask layerMask)
        {
            _layerMask = layerMask;
        }

        private void CalculateMesh()
        {
            float angle = _startingAngle;

            Vector3[] vertices = new Vector3[_rayCount + 1 + 1]; //1 for the origin, 1 for ray[0]
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[_rayCount * 3]; //for each poligon triangle we have 3 values

            vertices[0] = _origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 vertex;
                RaycastHit2D raycastHit2D = Physics2D.Raycast(_origin, Utilities.GetVectorFromAngle(angle), _viewDistance, _layerMask);

                if (raycastHit2D.collider == null)
                {
                    // No hit
                    vertex = _origin + Utilities.GetVectorFromAngle(angle) * _viewDistance;
                }
                else
                {
                    // Hit object
                    vertex = raycastHit2D.point;
                }

                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }
                vertexIndex++;
                angle -= _angleIncrease;
            }

            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
            _mesh.bounds = new Bounds(_origin, Vector3.one * 1000f);
        }
    }
}
