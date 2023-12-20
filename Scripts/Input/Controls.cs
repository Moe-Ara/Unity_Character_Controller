//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CharacterMovement
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""55a13aec-5a6d-4b4c-bb6a-90718753e458"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""07044d6a-8693-4677-b81e-65664ca92bf9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""c4a37b2b-f58e-4bed-bad7-b9b5233fc94f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4b64d549-fdcd-4bb9-8dfa-9a6e619309b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""28cc9761-81ca-495b-a15a-20944b18d14b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""e5bc0705-bbf1-49a5-9dfb-acd0f513a635"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""4274c722-fc7a-4609-8cf7-03c31c001825"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""866d7580-8041-4c95-927c-940e7bbc1ea8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""845d4d91-41e0-4345-aa9e-98cc0b8af61a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9f529ebc-378b-44db-9977-60b2b4281eeb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5a72236d-4580-4a5b-9400-3ec5c41b9c7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fc6ecc3f-7d0e-4c08-8c3e-4cad523c3bfd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ed21813-ed53-4f7d-8025-80e5d764fe1b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""352bac99-3185-463f-8879-2c95737e69c7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""61ffb665-6f37-4256-868a-926b41477af0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d50c7c2f-d5a9-4029-9790-83a42d023aa3"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e42c406b-d211-4420-98ff-6fe5dfb3624e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""280a58c7-f0a0-4f79-a5ff-09974f3a5355"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32270217-c493-45d1-8f18-6d7e8d0fb7f3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ced9c90c-08df-4b20-ba32-f4c686b44ccf"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c805672-37b0-4261-9c70-26362812f512"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f99c2bc-e04b-4a63-b080-d763509c083e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bad6d415-4fa0-44cb-9a06-539092539fd3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Control
            m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
            m_Control_Move = m_Control.FindAction("Move", throwIfNotFound: true);
            m_Control_Look = m_Control.FindAction("Look", throwIfNotFound: true);
            m_Control_Jump = m_Control.FindAction("Jump", throwIfNotFound: true);
            m_Control_Crouch = m_Control.FindAction("Crouch", throwIfNotFound: true);
            m_Control_Dash = m_Control.FindAction("Dash", throwIfNotFound: true);
            m_Control_Walk = m_Control.FindAction("Walk", throwIfNotFound: true);
            m_Control_Sprint = m_Control.FindAction("Sprint", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Control
        private readonly InputActionMap m_Control;
        private IControlActions m_ControlActionsCallbackInterface;
        private readonly InputAction m_Control_Move;
        private readonly InputAction m_Control_Look;
        private readonly InputAction m_Control_Jump;
        private readonly InputAction m_Control_Crouch;
        private readonly InputAction m_Control_Dash;
        private readonly InputAction m_Control_Walk;
        private readonly InputAction m_Control_Sprint;
        public struct ControlActions
        {
            private @Controls m_Wrapper;
            public ControlActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Control_Move;
            public InputAction @Look => m_Wrapper.m_Control_Look;
            public InputAction @Jump => m_Wrapper.m_Control_Jump;
            public InputAction @Crouch => m_Wrapper.m_Control_Crouch;
            public InputAction @Dash => m_Wrapper.m_Control_Dash;
            public InputAction @Walk => m_Wrapper.m_Control_Walk;
            public InputAction @Sprint => m_Wrapper.m_Control_Sprint;
            public InputActionMap Get() { return m_Wrapper.m_Control; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
            public void SetCallbacks(IControlActions instance)
            {
                if (m_Wrapper.m_ControlActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnLook;
                    @Jump.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnJump;
                    @Crouch.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnCrouch;
                    @Crouch.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnCrouch;
                    @Crouch.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnCrouch;
                    @Dash.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnDash;
                    @Walk.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnWalk;
                    @Walk.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnWalk;
                    @Walk.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnWalk;
                    @Sprint.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnSprint;
                }
                m_Wrapper.m_ControlActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Crouch.started += instance.OnCrouch;
                    @Crouch.performed += instance.OnCrouch;
                    @Crouch.canceled += instance.OnCrouch;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Walk.started += instance.OnWalk;
                    @Walk.performed += instance.OnWalk;
                    @Walk.canceled += instance.OnWalk;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                }
            }
        }
        public ControlActions @Control => new ControlActions(this);
        private int m_NewcontrolschemeSchemeIndex = -1;
        public InputControlScheme NewcontrolschemeScheme
        {
            get
            {
                if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
                return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
            }
        }
        public interface IControlActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnWalk(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
        }
    }
}