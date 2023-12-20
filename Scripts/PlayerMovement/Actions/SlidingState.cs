using UnityEngine;

namespace CharacterMovement
{
    public class SlidingState : IdleState
    {
        private RaycastHit _slopeHit;

        public SlidingState(PlayerController playerController, RaycastHit? SlopeHit) : base(playerController)
        {
            _playerController.stateText.SetText("Sliding");
            // _slopeHit = (RaycastHit)SlopeHit;
        }

        public override void Enter()
        {
            Debug.Log("Sliding Action");
        }

        public override void UpdateState(float deltaTime)
        {
        }

        public override void FixedUpdateState(float deltaTime)
        {
            var slopeHit = _playerController.OnSlope();
            if (slopeHit==null || slopeHit.Value.normal==Vector3.up)
            {
                _playerController.SwitchState(new IdleState(_playerController));
            }
            else
            {
                var slopeAngle = Vector3.Angle(slopeHit.Value.normal, Vector3.up);
                if (slopeAngle > _playerController.MaxSlopeAngle)
                {
                    _playerController.SlideDownSlope(_slopeHit.normal);
                }
            }


        }

        public override void Exit()
        {
        }
    }
}