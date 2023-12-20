using UnityEngine;

namespace CharacterMovement
{
    public class JumpingState:IdleState
    {
        private Vector3 _momentum;
        public JumpingState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Enter()
        {
            _playerController.stateText.SetText("Jumping");

            
            _playerController.FallingEvent += OnFall;
            _playerController.InputHandler.DashEvent += OnDash;
            _momentum =_playerController.RigidBody.velocity ;
            _momentum.y = 0;
            if (_playerController.PlayerAnimator)
            {
                _playerController.PlayerAnimator.Play(Animator.StringToHash("Jumping"));
            }
            _playerController.Jump(_playerController.JumpingForce*100);
            

        }

        private void OnFall()
        {
            _playerController.SwitchState(new FallingState(_playerController));
        }

        private void OnDash()
        {
            if(_playerController.DashCooldown>0)return;
            // Stops the Jump
            _playerController.RigidBody.AddForce(Vector3.down * _playerController.JumpingForce/2, ForceMode.Impulse);

            _playerController.SwitchState(new DashingState(_playerController));
        }


        public override void UpdateState(float deltaTime)
        {
            // // If was grounded before going into falling state (e.g Jumping from hill onto an uphill)
            // if (_playerController.IsGrounded() && Mathf.Approximately(_playerController.RigidBody.velocity.y, 0f)) 
            // {
            //     Debug.Log("Going from jump to move man");
            //     _playerController.SwitchAction(new MovingAction(_playerController));
            // }
  

        }

        public override void FixedUpdateState(float deltaTime)
        {
            if (_playerController.isGrounded)
            {
                _playerController.SwitchState(new IdleState(_playerController));
            }
            

            if (_playerController.CanMoveWhileJumping)
            {
                _momentum = _playerController.CalculateMovement();
            }

            _playerController.Move(_momentum,deltaTime);

        }

        public override void Exit()
        {
            _playerController.FallingEvent -= OnFall;
            _playerController.InputHandler.DashEvent -= OnDash;

        }
    }


}