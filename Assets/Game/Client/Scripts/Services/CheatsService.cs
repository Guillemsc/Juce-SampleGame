using System;
using Juce.Core.Service;
using SRDebugger;

namespace Game.Client.Services
{
    public class CheatsService : IService
    {
        public void Init()
        {
            DebugMaster debugMaster = new DebugMaster();
            debugMaster.Enable();

            SRDebug.Instance.IsTriggerEnabled = false;

            debugMaster.SRDebugger.Show.performed += (UnityEngine.InputSystem.InputAction.CallbackContext context) =>
            {
                SRDebug.Instance.ShowDebugPanel(DefaultTabs.Options);
            };
        }

        public void CleanUp()
        {

        }

        public void PushCheats(object obj)
        {
            SRDebug.Instance.AddOptionContainer(obj);
        }

        public void PopCheats(object obj)
        {
            SRDebug.Instance?.RemoveOptionContainer(obj);
        }
    }
}
