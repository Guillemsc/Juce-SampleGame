using System;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Managers;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class PointLineDespawnBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly PointLineViewSettings pointLineViewSettings;
        private readonly PointLineViewManager pointLineViewManager;
        private readonly PointsNumberViewManager pointsNumberViewManager;

        private bool enabled = false;

        private ShipView shipView;

        public PointLineDespawnBehaviour(TickablesService tickableService, PointLineViewSettings pointLineViewSettings,
            PointLineViewManager pointLineViewManager, PointsNumberViewManager pointsNumberViewManager)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(pointLineViewSettings);
            Contract.IsNotNull(pointLineViewManager);
            Contract.IsNotNull(pointsNumberViewManager);

            this.tickableService = tickableService;
            this.pointLineViewSettings = pointLineViewSettings;
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
            DespawnSections();
        }

        public void Start(ShipView shipView)
        {
            if (!enabled)
            {
                enabled = true;
            }

            Contract.IsNotNull(shipView);

            this.shipView = shipView;
        }

        private void DespawnSections()
        {
            if (shipView == null)
            {
                return;
            }

            if (pointLineViewManager.SpawnedPointLinesView.Count == 0)
            {
                return;
            }

            PointLineView currLine = pointLineViewManager.SpawnedPointLinesView[0];

            if (currLine.transform.position.y > shipView.transform.position.y - pointLineViewSettings.DespawnOffsetFromShip)
            {
                return;
            }

            pointLineViewManager.DespawnPointLineView(currLine);
        }
    }
}
