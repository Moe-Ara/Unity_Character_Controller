using Unity.VisualScripting;
using UnityEngine;

namespace CharacterMovement
{
    public class MovingState : IdleState
    {
        private float _additionalSpeed;
        private int _freeLookTreeHash = Animator.StringToHash("FreeLookTree");
        private const float _animatorDampTime = 0.1f;
        private readonly int _freeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
        private readonly int _crouchWalkBlendTree = Animator.StringToHash("CrouchWalkingTree");
        private readonly int _crouchForwardHash = Animator.StringToHash("CrouchWalkingForward");
        private readonly int _crouchRightHash = Animator.StringToHash("CrouchWalkingRight");
        private Vector3 _movement;
        private Vector3 _slopeMoveDirection;


        public MovingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            _playerController.stateText.SetText("Moving");


            _playerController.FallingEvent += OnFall;
            _playerController.InputHandler.JumpEvent += OnJump;
            _playerController.InputHandler.DashEvent += OnDash;
        }


        public override void UpdateState(float deltaTime)
        {
            if (_playerController.PlayerAnimator)
            {
                // _playerController.PlayerAnimator.SetFloat(_freeLookSpeedHash, 0f);
                if (_playerController.InputHandler.MoveDirection == Vector2.zero)
                {
                    _playerController.PlayerAnimator.SetFloat(_freeLookSpeedHash, 0.0f, _animatorDampTime, deltaTime);
                }

                if (_playerController.InputHandler.IsCrouching)
                {
                    _playerController.PlayerAnimator.Play(_crouchWalkBlendTree);
                    _playerController.PlayerAnimator.SetFloat(_crouchForwardHash,
                        !_playerController.InputHandler.IsMoving ? 0.0f : 1.0f, _animatorDampTime, deltaTime);
                }

                else
                {
                    _playerController.PlayerAnimator.Play(_freeLookTreeHash);


                    // _playerController.PlayerAnimator.CrossFadeInFixedTime(_freeLookTreeHash, 0.15f);

                    if (_playerController.InputHandler.IsSprinting)
                    {
                        _playerController.PlayerAnimator.SetFloat(_freeLookSpeedHash, 1.0f, _animatorDampTime,
                            deltaTime);
                    }
                    else if (_playerController.InputHandler.IsWalking)
                    {
                        _playerController.PlayerAnimator.SetFloat(_freeLookSpeedHash, 0.6f, _animatorDampTime,
                            deltaTime);
                    }
                    else
                    {
                        _playerController.PlayerAnimator.SetFloat(_freeLookSpeedHash, 0.8f, _animatorDampTime,
                            deltaTime);
                    }
                }
            }


        }

        public override void FixedUpdateState(float deltaTime)
        {
            if (_playerController.InputHandler.MoveDirection == Vector2.zero)
            {
                _playerController.SwitchState(new IdleState(_playerController));
            }
            _additionalSpeed = 0;


            _movement = _playerController.CalculateMovement();

            if (_playerController.InputHandler.IsSprinting)
            {
                _additionalSpeed = _playerController.SprintSpeed;
            }
            else if (_playerController.InputHandler.IsWalking)
            {
                _additionalSpeed = _playerController.WalkSpeed;
            }

            var slopeHit = _playerController.OnSlope();
            if (slopeHit != null && slopeHit.Value.normal != Vector3.up)
            {
                Debug.Log("On Slope");

                var slopeAngle = Vector3.Angle(slopeHit.Value.normal, Vector3.up);
                if (slopeAngle > _playerController.MaxSlopeAngle)
                {
                    //Sliding Down Slopes
                    _playerController.SwitchState(new SlidingState(_playerController, slopeHit));
                }
                else
                {
                    //Moving Down On Slopes
                    _slopeMoveDirection = Vector3.ProjectOnPlane(_movement, slopeHit.Value.normal).normalized;
                    _playerController.Move(_slopeMoveDirection, deltaTime, _additionalSpeed);
                    _playerController.RigidBody.AddForce(-_playerController.transform.up * _playerController.DOWNFORCE, ForceMode.Force);
                }

                if (_playerController.RigidBody.velocity.y > 0f)
                {
                    _playerController.RigidBody.AddForce(Vector3.down * _playerController.DOWNFORCE, ForceMode.Force);
                    // _playerController.RigidBody.useGravity = false;
                }
            }
            else
            {
                _playerController.RigidBody.useGravity = true;
                _playerController.Move(_movement, deltaTime, _additionalSpeed);
            }

            FaceMovementDirection(_movement, deltaTime);
        }

        public override void Exit()
        {
            _playerController.InputHandler.JumpEvent -= OnJump;
            _playerController.InputHandler.DashEvent -= OnDash;
            _playerController.FallingEvent -= OnFall;
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


        private void FaceMovementDirection(Vector3 movement, float deltaTime)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
            float targetYawRotation = targetRotation.eulerAngles.y;

            Quaternion targetYawQuaternion = Quaternion.Euler(0f, targetYawRotation, 0f);

            _playerController.RigidBody.MoveRotation(Quaternion.Slerp(
                _playerController.RigidBody.rotation,
                targetYawQuaternion,
                _playerController.RotationDamping * deltaTime
            ));
        }

        private void OnFall()
        {
            _playerController.SwitchState(new FallingState(_playerController));
        }
    }
}