using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace CharacterMovement
{
    public class FallingState : IdleState
    {
        
        private Vector3 _momentum;
        
        public FallingState(PlayerController playerController):base(playerController)
        {

        }

        public override void Enter()
        {
            _playerController.stateText.SetText("Falling");


            if (_playerController.PlayerAnimator)
            {
                _playerController.PlayerAnimator.Play(Animator.StringToHash("Falling"));
            }
            _playerController.InputHandler.DashEvent += OnDash;
            _momentum =  _playerController.RigidBody.velocity ;
            _momentum.y = 0f;

        }

        private void OnDash()
        {
            if(_playerController.DashCooldown>0)return;
            _playerController.SwitchState(new DashingState(_playerController));
        }


        public override void UpdateState(float deltaTime)
        {


        }
        public override void FixedUpdateState(float deltaTime)
        {
            if (!_playerController.IsGrounded() && _playerController.RigidBody.velocity.magnitude <0.0005f)
            {
                _momentum = Vector3.zero;
                Debug.Log("ADDFORCE");
            }
            if (_playerController.IsGrounded())
            {
                _playerController.SwitchState(new IdleState(_playerController));
            }
            if (_playerController.CanMoveWhileJumping)
            {
                _momentum = _playerController.CalculateMovement();
            }
            _playerController.Move(_momentum, deltaTime);
            // Fall(deltaTime);
        }

        public override void Exit()
        {
            _playerController.InputHandler.DashEvent -= OnDash;
        }

        // private void Fall(float deltaTime)
        // {
        //     // Apply an additional force to speed up the fall
        //     _playerController.RigidBody.AddForce(Vector3.down * (deltaTime * _playerController.JumpingForce), ForceMode.Force);
        // }
    }
}