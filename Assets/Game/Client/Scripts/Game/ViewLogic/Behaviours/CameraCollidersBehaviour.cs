using System;
using UnityEngine;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Settings;

namespace Game.Client.ViewLogic
{
    public class CameraCollidersBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly WorldSettings worldSettings;
        private readonly CamerasSettings cameraSettings;
        private readonly CameraCollidersSettings cameraCollidersSettings;

        private GameObject leftCameraCollider;
        private GameObject rightCameraCollider;

        public CameraCollidersBehaviour(TickablesService tickableService,
            WorldSettings worldSettings,
            CamerasSettings cameraSettings,
            CameraCollidersSettings cameraCollidersSettings)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(worldSettings);
            Contract.IsNotNull(cameraSettings);
            Contract.IsNotNull(cameraCollidersSettings);

            this.tickableService = tickableService;
            this.worldSettings = worldSettings;
            this.cameraSettings = cameraSettings;
            this.cameraCollidersSettings = cameraCollidersSettings;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);

            Contract.IsNotNull(cameraSettings.ShipViewVirtualCamera);
            Contract.IsNotNull(cameraCollidersSettings.CameraColliderPrefab);

            leftCameraCollider = cameraCollidersSettings.CameraColliderPrefab.Instantiate(worldSettings.WorldGameObject.transform);
            rightCameraCollider = cameraCollidersSettings.CameraColliderPrefab.Instantiate(worldSettings.WorldGameObject.transform);
        }

        protected override void OnDisable()
        {
            leftCameraCollider.Destroy();
            rightCameraCollider.Destroy();

            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            float leftSidePosition = cameraSettings.ShipViewCamera.GetLeftSideWorldPosition() - cameraCollidersSettings.Offset;
            leftCameraCollider.transform.position = new Vector2(leftSidePosition, cameraSettings.ShipViewCamera.transform.position.y);

            float rightSidePosition = cameraSettings.ShipViewCamera.GetRightSideWorldPosition() + cameraCollidersSettings.Offset;
            rightCameraCollider.transform.position = new Vector2(rightSidePosition, cameraSettings.ShipViewCamera.transform.position.y);
        }
    }
}

