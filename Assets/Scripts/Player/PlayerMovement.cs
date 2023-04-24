using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 12f;
        [SerializeField] private float _gravityScale = 2f;

        private Vector2 _velocity = Vector2.zero;
        private Quaternion _rotation;
        private Rigidbody2D _rigidbody2D;
        private GroundSensor _groundSensor;

        private float _epsilon = 0.01f;
        private float _turnRight = 180;
        private float _turnLeft = 0;
        private float _horizontal;

        public bool IsMove => _horizontal != 0;

        private void Start()
        {
            _groundSensor = GetComponentInChildren<GroundSensor>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _velocity += _gravityScale * Time.deltaTime * Physics2D.gravity;

            if (Mathf.Abs(_rigidbody2D.velocity.y) < _epsilon)
            {
                _velocity.y = 0;
            }

            _velocity.x = _horizontal * _moveSpeed;

            if (_horizontal > 0)
            {
                _rotation.y = _turnRight;
            }
            else if (_horizontal < 0)
            {
                _rotation.y = _turnLeft;
            }

            transform.rotation = _rotation;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_groundSensor.IsGrounded)
                {
                    _velocity += Vector2.up * _jumpForce;
                }
            }

            _rigidbody2D.velocity = _velocity;
        }
    }
}