using UnityEngine;
using CustomUtilities;

namespace AsteroidS
{
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField] private float _fov = 90f;
        [SerializeField] private float _viewDistance = 20f;
        [SerializeField] private LayerMask _layerMask = 7;
        [SerializeField] private int _rayCount = 50;
        private Mesh _mesh;
        public Vector3 _origin;
        public float _startingAngle;
        private float _angleIncrease;

        private void Start()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;
            _origin = Vector3.zero;
            _angleIncrease = _fov / _rayCount;
        }

        private void LateUpdate()
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

        public void SetOrigin(Vector3 origin)
        {
            _origin = origin;
        }

        public void SetAimDerection(Vector3 direction)
        {
            _startingAngle = Utilities.GetAngleFromVectorFloat(direction) + _fov / 2f;
        }

        public void SetFoV(float fov)
        {
            _fov = fov;
        }

        public void SetViewDistance(float distance)
        {
            _viewDistance = distance;
        }
    }
}
