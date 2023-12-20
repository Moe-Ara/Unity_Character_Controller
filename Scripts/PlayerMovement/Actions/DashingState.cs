using Unity.VisualScripting;
using UnityEngine;

namespace CharacterMovement
{
    public class DashingState: IdleState
    {
        private float _dashTimer;
        public DashingState(PlayerController playerController) : base(playerController)
        {
            
        }

        public override void Enter()
        {
            _playerController.stateText.SetText("Dashing");

            _dashTimer = _playerController.DashDuration;
        }

        public override void UpdateState(float deltaTime)
        {

            

        }

        public override void FixedUpdateState(float deltaTime)
        {
            if (_dashTimer <= 0f)
            {
                _playerController.SwitchState(new IdleState(_playerController));
            }
            Dash();
        }

        public override void Exit()
        {
            
        }

        private void Dash()
        {
            _playerController.DashCooldown = 3f;
            _dashTimer-=Time.fixedDeltaTime;
            if (!(_dashTimer > 0f)) return;

            // Calculate the target position based on the dash distance
            var dashTarget = _playerController.RigidBody.position + _playerController.transform.forward * _playerController.DashLength/10;
            // Perform a raycast to check for obstacles
            RaycastHit hit;
            
            if (Physics.Raycast(_playerController.RigidBody.position, _playerController.transform.forward, out hit, _playerController.DashLength / 10))
            {
                // If the ray hits an obstacle, adjust the dash target
                dashTarget = hit.point;
            }
            // Interpolate the player's position using MovePosition
            // _playerController.RigidBody.AddForce(Vector3.Lerp(_playerController.RigidBody.position, dashTarget, 1f - _dashTimer / _playerController.DashLength),ForceMode.Impulse);
            _playerController.RigidBody.MovePosition(dashTarget);
        }
    }
}