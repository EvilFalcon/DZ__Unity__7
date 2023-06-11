using UnityEngine;

namespace Enemi
{
    public class WaypointMovement : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private float _speed;

        private Quaternion _transformRotation;
        private Transform[] _points;
        
        private int _currentPoint;
        private float _turnRight = 180;
        private float _turnLeft = 0;

        private void Start()
        {
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _path.childCount; i++)
            {
                _points[i] = _path.GetChild(i);
            }
        }

        private void Update()
        {
            Transform targeTransform = _points[_currentPoint];
            transform.position =
                Vector3.MoveTowards(transform.position, targeTransform.position, _speed * Time.deltaTime);

            if (transform.position == targeTransform.position)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }

            if (gameObject.transform.position.x >= targeTransform.position.x)
            {
                _transformRotation.y = _turnLeft;
            }
            else
            {
                _transformRotation.y = _turnRight;
            }

            transform.rotation = _transformRotation;
        }
    }
}