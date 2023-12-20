using UnityEngine;

namespace CharacterMovement
{
    public class IdleState : State
    {
        private float _additionalSpeed;
        private int _idleStateHash= Animator.StringToHash("IdleState");
        private const float _animatorDampTime = 0.1f;

        protected PlayerController _playerController;

        public IdleState(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public override void Enter()
        {
            _playerController.stateText.SetText("Idle");


            _playerController.FallingEvent += OnFall;
            _playerController.InputHandler.JumpEvent += OnJump;
            _playerController.InputHandler.DashEvent += OnDash;
            if (_playerController.PlayerAnimator)
            {
                _playerController.PlayerAnimator.SetFloat(_idleStateHash, 0f);
                _playerController.PlayerAnimator.CrossFadeInFixedTime(_idleStateHash, 0.15f);
                _playerController.PlayerAnimator.Play(_idleStateHash);
            }
        }

        private void OnFall()
        {
            _playerController.SwitchState(new FallingState(_playerController));
        }

        public override void UpdateState(float deltaTime)
        {

        }

        public override void FixedUpdateState(float deltaTime)
        {
            if (_playerController.RigidBody.velocity.y < 0 && !_playerController.IsGrounded())
            {
                _playerController.SwitchState(new FallingState(_playerController));
            }

            if (_playerController.InputHandler.IsMoving &&_playerController.IsGrounded())
            {
                _playerController.SwitchState(new MovingState(_playerController));
            }
            var slopeHit = _playerController.OnSlope();
            if (!slopeHit?.collider) return;
            if (slopeHit?.normal == Vector3.up) return;
            var slopeAngle = Vector3.Angle(slopeHit.Value.normal, Vector3.up);
            if (slopeAngle > _playerController.MaxSlopeAngle)
            {

                _playerController.SwitchState(new SlidingState(_playerController,slopeHit));
            }
            Debug.Log("ON SLOPE");

            if (!(_playerController.RigidBody.velocity.y > 0f)) return;
            Debug.Log("ADDED DOWN FORCE");
            _playerController.RigidBody.AddForce(Vector3.down * (_playerController.DOWNFORCE * 2),ForceMode.Force);
            // _playerController.RigidBody.useGravity = false;
        }


        public override void Exit()
        {
            _playerController.FallingEvent -= OnFall;
            _playerController.InputHandler.JumpEvent -= OnJump;
            _playerController.InputHandler.DashEvent -= OnDash;
        }

        private void OnDash()
        {
            if (_playerController.DashCooldown > 0) return;

            _playerController.SwitchState(new DashingState(_playerController));
        }

        private void OnJump()
        {
            _playerController.SwitchState(new JumpingState(_playerController));
        }
    }
}