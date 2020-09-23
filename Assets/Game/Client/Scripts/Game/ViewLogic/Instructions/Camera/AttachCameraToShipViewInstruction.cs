using System;
using System.Threading.Tasks;
using Cinemachine;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class AttachCameraToShipViewInstruction : InstantInstruction
    {
        private readonly ShipViewManager shipViewManager;
        private readonly CinemachineVirtualCamera shipCamera;

        public AttachCameraToShipViewInstruction(ShipViewManager shipViewManager,
            CinemachineVirtualCamera shipCamera)
        {
            Contract.IsNotNull(shipViewManager);
            Contract.IsNotNull(shipCamera);

            this.shipViewManager = shipViewManager;
            this.shipCamera = shipCamera;
        }

        protected override void OnInstantStart()
        {
            ShipView shipView = shipViewManager.GetShipView();

            shipCamera.Follow = shipView.gameObject.transform;
        }
    }
}
