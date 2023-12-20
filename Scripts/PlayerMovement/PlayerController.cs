
using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace CharacterMovement
{
    public class PlayerController:StateController
    {
        //
        // [SerializeField, Range(0, 90)]
        // float maxGroundAngle = 25f, maxStairsAngle = 50f;
        //
        Vector3 _contactNormal, _steepNormal;
        private int _groundContactCount , _steepContactCount;
        float _minGroundDotProduct, _minStairsDotProduct;
        private int _stepsSinceLastGrounded;
        private Vector3 _previousPosition;
        // public Vector3 Velocity { get; private set; }
        public float DOWNFORCE;
        
        [field:SerializeField] public Rigidbody RigidBody { get; private set; }
        [field:SerializeField] public InputHandler InputHandler { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float SprintSpeed { get; private set; }
        [field: SerializeField] public float WalkSpeed { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
        [field: SerializeField] public float RotationDamping { get; private set; }
        [field: SerializeField] public float DashDuration { get; private set; }
        [field: SerializeField] public float DashLength { get; private set; }
        [field: SerializeField] public float DashCooldown { get; set; }
        [field: SerializeField] public float JumpingForce { get; private set; }
        [field: SerializeField] public CapsuleCollider CapsuleCollider { get; private set; }
        [field: SerializeField] public LayerMask GroundLayerMask { get; private set; }
        [field: SerializeField] public bool CanMoveWhileJumping { get; private set; }
        [field: SerializeField] public Animator PlayerAnimator { get; private set; }

        [field:SerializeField, Range(0, 90)]
        public float MaxSlopeAngle { get; private set; }
        public float slideForce = 10f;   // Adjust the force applied during sliding.

        
        public float allignment;
        
        
        public Action FallingEvent;


        public  float _groundCheckDistance = 1.1f;
        private float _originalHeight;
        private Vector3 _originalCenter;
        private bool isCrouched;
        public bool isGrounded;
        private int _stairsMask=-1;

        // void OnValidate () {
        //     _minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
        //     _minStairsDotProduct = Mathf.Cos(maxStairsAngle * Mathf.Deg2Rad);
        // }

        public TextMeshProUGUI stateText;
        public void Start()
        {
            // PlayerAnimator = gameObject.GetComponent<Animator>()?? null;
            InputHandler.CrouchEvent += OnCrouch;
            WalkSpeed *= -1;
            CapsuleCollider=gameObject.GetComponent<CapsuleCollider>() ?? gameObject.AddComponent<CapsuleCollider>();
            RigidBody = gameObject.GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
            RigidBody.freezeRotation = true;
            RigidBody.interpolation = RigidbodyInterpolation.Interpolate;
            // OnValidate();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MainCameraTransform = Camera.main.transform;
            _previousPosition = RigidBody.position;
            _originalCenter = CapsuleCollider.center;
            _originalHeight = CapsuleCollider.height;
            SwitchState(new IdleState(this));
        }

        private void OnCrouch()
        {
            isCrouched = true;
            crouch();
            
        }


        public override void Move(Vector3 moveDirection, float deltaTime,float additionalSpeed=0)
        {
            moveDirection=Vector3.ClampMagnitude(moveDirection, 1);
            var velocity = moveDirection * ((Speed+additionalSpeed)*100 * deltaTime);
            RigidBody.velocity = new Vector3(velocity.x, RigidBody.velocity.y, velocity.z);
            //
            //
            // moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
            //
            // // Calculate the force to be applied based on the desired velocity change.
            // Vector3 targetVelocity = moveDirection * (Speed + additionalSpeed);
            // Vector3 velocityChange = targetVelocity - RigidBody.velocity;
            //
            // // Calculate the force needed to achieve the velocity change.
            // Vector3 force = velocityChange / deltaTime;
            //
            // // Apply the force using Rigidbody.AddForce.
            // RigidBody.AddForce(velocityChange, ForceMode.Force);
            // CancelMomentum();
        }

        void CancelMomentum()
        {
            RigidBody.AddForce(Vector3.right*-RigidBody.velocity.x, ForceMode.Force);
            RigidBody.AddForce(Vector3.forward*-RigidBody.velocity.z, ForceMode.Force);

        }
        

        
        
        // bool CheckSteepContacts () {
        //     if (_steepContactCount > 1) {
        //         _steepNormal.Normalize();
        //         if (_steepNormal.y >= _minGroundDotProduct) {
        //             _steepContactCount = 0;
        //             _groundContactCount = 1;
        //             _contactNormal = _steepNormal;
        //             return true;
        //         }
        //     }
        //     return false;
        // }

        // bool SnapToGround () {
        //     
        //     if (_stepsSinceLastGrounded > 1) {
        //         return false;
        //     }
        //     var topPoint = transform.position + Vector3.up * CapsuleCollider.radius;
        //     var bottomPoint = transform.position - Vector3.up * CapsuleCollider.radius + (Vector3.up * CapsuleCollider.height);
        //
        //
        //     RaycastHit hit;
        //     if (!Physics.CapsuleCast(topPoint, bottomPoint, CapsuleCollider.radius, -transform.up, out hit,1f, GroundLayerMask,
        //             QueryTriggerInteraction.Ignore)) {
        //         Debug.Log("Raycasting");
        //         // return false;
        //     }
        //     if (hit.normal.y < _minGroundDotProduct) {
        //         Debug.Log("False" );
        //         // return false;
        //     }
        //     _groundContactCount = 1;
        //     _contactNormal = hit.normal;
        //     float speed = RigidBody.velocity.magnitude;
        //     float dot = Vector3.Dot(RigidBody.velocity, hit.normal);
        //     Debug.Log("SetUpShit" );
        //     // if (dot > 0f) {
        //         RigidBody.velocity = (RigidBody.velocity - hit.normal * dot).normalized * speed;
        //         Debug.Log("ChangeShit" );
        //     // }
        //     return true;
        // }
        
        //
        // void ClearState () {
        //     _groundContactCount = _steepContactCount = 0;
        //     _contactNormal = _steepNormal = Vector3.zero;
        // }

        protected override void customUpdate(float deltaTime)
        {
            if (DashCooldown > 0)
            {
                DashCooldown -= deltaTime;
            }
            if (isCrouched && !InputHandler.IsCrouching)
            {
                resetCrouching();
                Debug.Log("resetting");
            }   
            if (RigidBody.velocity.y < 0 && !IsGrounded())
            {
                FallingEvent?.Invoke();
            }

            if (IsGrounded())
            {
                isGrounded = true;
                _stepsSinceLastGrounded = 0;
            }
            else
            {
                isGrounded = false;
            }
        }
        protected override void customFixedUpdate(float deltaTime)
        {
            _stepsSinceLastGrounded += 1;

            // Velocity = CalculateVelocity(deltaTime);
            AlignToSurface(deltaTime);
            if (IsGrounded() )
            {
                _stepsSinceLastGrounded = 0;
                if (_groundContactCount > 1)
                {
                    _contactNormal.Normalize();
                }

            }
            else
            {
                _contactNormal = Vector3.up;
            }
           

        }

        public void Jump(float jumpForce)
        {

            if(!IsGrounded()) return;
            RigidBody.AddForce(Vector3.up * (jumpForce * Time.fixedDeltaTime), ForceMode.Impulse);

        }

        public bool IsGrounded()
        {
            RaycastHit hitInfo;
            var topPoint = transform.position + Vector3.up * CapsuleCollider.radius;
            var bottomPoint = transform.position - Vector3.up * CapsuleCollider.radius + (Vector3.up * CapsuleCollider.height);
            Physics.CapsuleCast(topPoint, bottomPoint, CapsuleCollider.radius, -transform.up, out hitInfo, _groundCheckDistance, GroundLayerMask,
                QueryTriggerInteraction.Ignore);
            // hitInfo = CapsuleCaster(_groundCheckDistance);
            return hitInfo.collider;
        }

        private RaycastHit CapsuleCaster(float distance,Vector3 direction)
        {
            RaycastHit hitInfo;
            var topPoint = transform.position + Vector3.up * CapsuleCollider.radius;
            var bottomPoint = transform.position - Vector3.up * CapsuleCollider.radius + (Vector3.up * CapsuleCollider.height);

            Physics.CapsuleCast(topPoint, bottomPoint, CapsuleCollider.radius, direction, out hitInfo, distance, GroundLayerMask,
                QueryTriggerInteraction.Ignore);
            return hitInfo;
        }

        public Vector3 CalculateVelocity(float deltaTime)
        {
            var velocity = (RigidBody.position - _previousPosition) / deltaTime;
            _previousPosition = RigidBody.position;
            return velocity;
        }
        private void resetCrouching()
        {
            isCrouched = false;
            CapsuleCollider.center = _originalCenter;
            CapsuleCollider.height = _originalHeight;
            if (PlayerAnimator && !InputHandler.IsMoving)
            {
                PlayerAnimator.Play( Animator.StringToHash("IdleState"));
            }
        }

        private void crouch()
        {
            // if (PlayerAnimator && !InputHandler.IsMoving)
            // {
            //     PlayerAnimator.Play( Animator.StringToHash("Crouch"));
            // }
            CapsuleCollider.height /=2 ;
            CapsuleCollider.center=new Vector3(CapsuleCollider.center.x,
                _originalCenter.y - (_originalHeight - CapsuleCollider.height) * 0.5f,
                CapsuleCollider.center.z);


        }

        private void OnDestroy()
        {
            InputHandler.CrouchEvent -= OnCrouch;
        }

        public Vector3 CalculateMovement()
        {
            var forward = MainCameraTransform.forward;
            var right =MainCameraTransform.right;
            forward.y = right.y = 0;
            forward.Normalize();
            right.Normalize();
            
            return forward * InputHandler.MoveDirection.y +
                   right * InputHandler.MoveDirection.x;
        }

        public void AlignToSurface(float deltaTime)
        {
            // RaycastHit hit;
            // if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            // {
            //     var groundNormal = hit.normal;
            //     var targetRotation=Quaternion.FromToRotation(transform.up, groundNormal)*RigidBody.rotation;
            //     RigidBody.MoveRotation(Quaternion.Slerp(RigidBody.rotation, targetRotation, RotationDamping* deltaTime));
            // }
            Vector3 capsuleBottom =
                transform.position - Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius);
            Vector3 capsuleTop =
                transform.position + Vector3.up * (CapsuleCollider.height / 2 - CapsuleCollider.radius);

            RaycastHit hit= CapsuleCaster(Mathf.Infinity,Vector3.down);
            // Physics.CapsuleCast(capsuleBottom, capsuleTop, CapsuleCollider.radius, Vector3.down, out hit, Mathf.Infinity,GroundLayerMask)
            if (hit.collider)
            {
                // Get the normal of the ground surface

                Vector3 groundNormal = hit.normal;

                // Visualize the capsule cast
                Debug.DrawLine(capsuleBottom, hit.point, Color.red); // Line from capsule bottom to hit point
                Debug.DrawLine(capsuleTop, hit.point, Color.blue);    // Line from capsule top to hit point
                
                // Calculate the rotation to align with the ground normal
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, groundNormal) * RigidBody.rotation;
                Vector3 targetEulerAngles = targetRotation.eulerAngles;
                // Smoothly rotate the character's Rigidbody to the target rotation
                // RigidBody.MoveRotation(Quaternion.Euler(Vector3.Slerp(RigidBody.rotation.eulerAngles,targetEulerAngles,allignment*deltaTime)));
                RigidBody.MoveRotation(Quaternion.Slerp(RigidBody.rotation, targetRotation, allignment * deltaTime));

            }
        }
        // void OnCollisionEnter (Collision collision) {
        //     EvaluateCollision(collision);
        // }
        //
        // void OnCollisionStay (Collision collision) {
        //     EvaluateCollision(collision);
        // }
    //
    //     void EvaluateCollision (Collision collision) {
    //         float minDot = GetMinDot(collision.gameObject.layer);
    //         for (int i = 0; i < collision.contactCount; i++) {
    //             Vector3 normal = collision.GetContact(i).normal;
    //             if (normal.y >= minDot) {
    //                 _groundContactCount += 1;
    //                 _contactNormal += normal;
    //             }
    //             else if (normal.y > -0.01f) {
    //                 _steepContactCount += 1;
    //                 _steepNormal += normal;
    //             }
    //         }
    //     }
    //     float GetMinDot (int layer) {
    //         return (_stairsMask & (1 << layer)) == 0 ?
    //             _minGroundDotProduct : _minStairsDotProduct;
    //     }
    
    public RaycastHit? OnSlope()
    {
        RaycastHit slopeHit;
         if (Physics.Raycast(RigidBody.position, -transform.up, out slopeHit,
                 CapsuleCollider.height / 2 + 0.7f))
        {
            return slopeHit;
        }
         return null;
    }
    public void SlideDownSlope(Vector3 slopeNormal)
    {
        // Calculate the force based on the slope normal.
        Vector3 slideForceDirection = Vector3.Cross(slopeNormal, Vector3.down).normalized;
        Vector3 slideForceVector = slideForce * slideForceDirection;
        // Apply the force to simulate sliding.
        RigidBody.AddForce(slideForceVector, ForceMode.Force);
    }
    
    }
    

}
