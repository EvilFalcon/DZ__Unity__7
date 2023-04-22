using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GroundSensor : MonoBehaviour
    {
        private CircleCollider2D _circleCollider2D;
        private const float RadiusCollider2d = 0.05f;
        public bool IsGrounded { get; private set; }

        private void Start()
        {
            _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
            _circleCollider2D.radius = RadiusCollider2d;
            _circleCollider2D.isTrigger = true;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            IsGrounded = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsGrounded = false;
        }
    }
}