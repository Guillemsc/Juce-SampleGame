using System;
using Juce.Utils.Contracts;

namespace Game.Client.ViewLogic
{
    public class UserInput 
    {
        private readonly InputMaster inputMaster;

        public event Action OnDirectionTrigger;

        public UserInput(InputMaster inputMaster)
        {
            Contract.IsNotNull(inputMaster);

            this.inputMaster = inputMaster;

            inputMaster.Enable();

            inputMaster.Player.DirectionTrigger.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
            {
                OnDirectionTrigger?.Invoke();
            };
        }

        public void Disable()
        {
            inputMaster.Disable();
        }
    }
}
