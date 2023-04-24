using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private GroundSensor _groundSensor;
        private Animator _animator;
        private PlayerMovement _playerMovement;
        
        private int _animationState = Animator.StringToHash("AnimState");
        private int _grounded = Animator.StringToHash("Grounded");

        private void Start()
        {
            _groundSensor = GetComponentInChildren<GroundSensor>();
            _playerMovement = GetComponent<PlayerMovement>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _animator.SetBool(_animationState, _playerMovement.IsMove);
            _animator.SetBool(_grounded, _groundSensor.IsGrounded);
        }
    }
}