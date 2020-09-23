// GENERATED AUTOMATICALLY FROM 'Assets/SampleGame/Config/Input/DebugMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DebugMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DebugMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugMaster"",
    ""maps"": [
        {
            ""name"": ""SRDebugger"",
            ""id"": ""ad558995-c494-4063-a9a7-f80fc3bd7e8a"",
            ""actions"": [
                {
                    ""name"": ""Show"",
                    ""type"": ""Button"",
                    ""id"": ""a794e914-1fd1-4306-8c42-428f10df9d63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f10b2cf5-d61b-4c47-87de-e3ab5b599e56"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Show"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d365c1e3-0fc2-4ba1-97a3-e79009089d29"",
                    ""path"": ""<Touchscreen>/touch3/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Show"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SRDebugger
        m_SRDebugger = asset.FindActionMap("SRDebugger", throwIfNotFound: true);
        m_SRDebugger_Show = m_SRDebugger.FindAction("Show", throwIfNotFound: true);
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

    // SRDebugger
    private readonly InputActionMap m_SRDebugger;
    private ISRDebuggerActions m_SRDebuggerActionsCallbackInterface;
    private readonly InputAction m_SRDebugger_Show;
    public struct SRDebuggerActions
    {
        private @DebugMaster m_Wrapper;
        public SRDebuggerActions(@DebugMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Show => m_Wrapper.m_SRDebugger_Show;
        public InputActionMap Get() { return m_Wrapper.m_SRDebugger; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SRDebuggerActions set) { return set.Get(); }
        public void SetCallbacks(ISRDebuggerActions instance)
        {
            if (m_Wrapper.m_SRDebuggerActionsCallbackInterface != null)
            {
                @Show.started -= m_Wrapper.m_SRDebuggerActionsCallbackInterface.OnShow;
                @Show.performed -= m_Wrapper.m_SRDebuggerActionsCallbackInterface.OnShow;
                @Show.canceled -= m_Wrapper.m_SRDebuggerActionsCallbackInterface.OnShow;
            }
            m_Wrapper.m_SRDebuggerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Show.started += instance.OnShow;
                @Show.performed += instance.OnShow;
                @Show.canceled += instance.OnShow;
            }
        }
    }
    public SRDebuggerActions @SRDebugger => new SRDebuggerActions(this);
    public interface ISRDebuggerActions
    {
        void OnShow(InputAction.CallbackContext context);
    }
}
