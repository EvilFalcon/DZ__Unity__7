using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 12f;
        [SerializeField] private float _gravityScale = 2f;

        private Vector2 _velocity = Vector2.zero;
        private Rigidbody2D _rigidbody2D;
        private GroundSensor _groundSensor;

        private void Awake()
        {
            Instantiate(new GameObject("Ground Sensor"), transform).gameObject.AddComponent(typeof(GroundSensor));
        }

        private void Start()
        {
            _groundSensor = gameObject.GetComponentInChildren<GroundSensor>();
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            _velocity += _gravityScale * Time.deltaTime * Physics2D.gravity;

            if (Mathf.Abs(_rigidbody2D.velocity.y) < 0.01f)
            {
                _velocity.y = 0;
            }

            _velocity.x = horizontal * _moveSpeed;

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