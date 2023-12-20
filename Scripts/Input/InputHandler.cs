using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterMovement
{
    public class InputHandler : MonoBehaviour, Controls.IControlActions
    {

    #region Attributes

    private Controls _controls;
    public Vector2 MoveDirection { get; private set; }
    public bool IsCrouching { get; private set; }
    public bool IsSprinting { get; private set; }
    public bool IsWalking { get; private set; }
    public bool IsMoving { get; private set; }

    #endregion

    #region Events

    public event Action JumpEvent;
    public event Action DashEvent;
    public event Action CrouchEvent;

    #endregion

    public void Start()
    {
        _controls = new Controls();
        _controls.Control.SetCallbacks(this);
        _controls.Control.Enable();
    }

    public void OnDestroy()
    {
        _controls.Control.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        IsMoving = true;
        MoveDirection = context.ReadValue<Vector2>();
        if (context.canceled)
        {
            IsMoving = false;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        JumpEvent?.Invoke();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsCrouching = true;
            CrouchEvent?.Invoke();
        }
        else if (context.canceled)
        {
            IsCrouching = false;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        DashEvent?.Invoke();
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsWalking = true;
        }
        else if (context.canceled)
        {
            IsWalking = false;
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsSprinting = true;
        }
        else if (context.canceled)
        {
            IsSprinting = false;
        }
    }
    }
}