using System;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Managers;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class PointLineSpawnBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly PointLineViewSettings pointLineViewSettings;
        private readonly PointsNumberViewSettings pointsNumberViewSettings;
        private readonly CamerasSettings cameraSettings;
        private readonly PointLineViewManager pointLineViewManager;
        private readonly PointsNumberViewManager pointsNumberViewManager;

        private bool enabled = false;

        private ShipView shipView;
        private float currPosition;
        private bool usedStartingDistance;

        public PointLineSpawnBehaviour(TickablesService tickableService, PointLineViewSettings pointLineViewSettings,
            PointsNumberViewSettings pointsNumberViewSettings, CamerasSettings cameraSettings,
            PointLineViewManager pointLineViewManager, PointsNumberViewManager pointsNumberViewManager)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(pointLineViewSettings);
            Contract.IsNotNull(pointsNumberViewSettings);
            Contract.IsNotNull(cameraSettings);
            Contract.IsNotNull(pointLineViewManager);
            Contract.IsNotNull(pointsNumberViewManager);

            this.tickableService = tickableService;
            this.pointLineViewSettings = pointLineViewSettings;
            this.pointsNumberViewSettings = pointsNumberViewSettings;
            this.cameraSettings = cameraSettings;
            this.pointLineViewManager = pointLineViewManager;
            this.pointsNumberViewManager = pointsNumberViewManager;

            this.shipView = null;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);
        }

        protected override void OnDisable()
        {
            shipView = null;

            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            SpawnNewPointLine();
        }

        public void Start(ShipView shipView)
        {
            if (!enabled)
            {
                enabled = true;
            }

            Contract.IsNotNull(shipView);

            this.shipView = shipView;
            currPosition = shipView.transform.position.y;
            usedStartingDistance = false;
        }

        private void SpawnNewPointLine()
        {
            if (shipView == null)
            {
                return;
            }

            float checkingPosition = currPosition;

            if (!usedStartingDistance)
            {
                checkingPosition += pointLineViewSettings.StartingDistance;
            }
            else
            {
                checkingPosition += pointLineViewSettings.DistanceBetweenPointLines;
            }

            if (checkingPosition > shipView.transform.position.y + pointLineViewSettings.SpawnOffsetFromShip)
            {
                return;
            }

            usedStartingDistance = true;

            PointLineView pointLineView = pointLineViewManager.SpawnPointLineView();
            pointLineView.transform.SetPositionY(checkingPosition);

            float leftSidePosition = cameraSettings.ShipViewCamera.GetLeftSideWorldPosition();
            PointsNumberView pointsNumberView = pointsNumberViewManager.SpawnPointsNumberView();
            pointsNumberView.transform.SetPositionX(leftSidePosition + pointsNumberViewSettings.PositionOffset.x);
            pointsNumberView.transform.SetPositionY(checkingPosition + pointsNumberViewSettings.PositionOffset.y);

            currPosition = checkingPosition;

            SpawnNewPointLine();
        }
    }
}
