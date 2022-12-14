//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayersControls"",
            ""id"": ""a60a3f94-ba4b-44cd-82a4-a7fb470c951e"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""627d36d6-58d1-40ea-a85a-49956caeb66a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""bb011242-7c94-4d6b-a5b1-480572457766"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill"",
                    ""type"": ""Button"",
                    ""id"": ""9119ca8d-2ea6-4eff-84fe-d823d2382414"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3f47115d-714f-46e6-b700-d34a77d4924c"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f76999dd-d6e2-460f-87b7-f0dfc0fbb2f8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""858fb184-bce7-4127-aa2b-e677fb5d96ad"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayersControls
        m_PlayersControls = asset.FindActionMap("PlayersControls", throwIfNotFound: true);
        m_PlayersControls_Click = m_PlayersControls.FindAction("Click", throwIfNotFound: true);
        m_PlayersControls_Menu = m_PlayersControls.FindAction("Menu", throwIfNotFound: true);
        m_PlayersControls_Skill = m_PlayersControls.FindAction("Skill", throwIfNotFound: true);
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

    // PlayersControls
    private readonly InputActionMap m_PlayersControls;
    private IPlayersControlsActions m_PlayersControlsActionsCallbackInterface;
    private readonly InputAction m_PlayersControls_Click;
    private readonly InputAction m_PlayersControls_Menu;
    private readonly InputAction m_PlayersControls_Skill;
    public struct PlayersControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayersControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_PlayersControls_Click;
        public InputAction @Menu => m_Wrapper.m_PlayersControls_Menu;
        public InputAction @Skill => m_Wrapper.m_PlayersControls_Skill;
        public InputActionMap Get() { return m_Wrapper.m_PlayersControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayersControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayersControlsActions instance)
        {
            if (m_Wrapper.m_PlayersControlsActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnClick;
                @Menu.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnMenu;
                @Skill.started -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnSkill;
                @Skill.performed -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnSkill;
                @Skill.canceled -= m_Wrapper.m_PlayersControlsActionsCallbackInterface.OnSkill;
            }
            m_Wrapper.m_PlayersControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Skill.started += instance.OnSkill;
                @Skill.performed += instance.OnSkill;
                @Skill.canceled += instance.OnSkill;
            }
        }
    }
    public PlayersControlsActions @PlayersControls => new PlayersControlsActions(this);
    public interface IPlayersControlsActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnSkill(InputAction.CallbackContext context);
    }
}
