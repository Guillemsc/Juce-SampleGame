using System;
using System.Collections.Generic;
using UnityEngine;
using Juce.Utils.Contracts;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.Managers
{
    public class ShipViewManager
    {
        private readonly WorldSettings worldSettings;
        private readonly ShipViewSettings shipViewSettings;
        private readonly List<ShipView> shipViews = new List<ShipView>();

        public ShipViewManager(WorldSettings worldSettings, ShipViewSettings shipViewSettings)
        {
            Contract.IsNotNull(worldSettings);
            Contract.IsNotNull(shipViewSettings);

            this.worldSettings = worldSettings;
            this.shipViewSettings = shipViewSettings;
        }

        public void SpawnShipView()
        {
            Contract.IsNotNull(shipViewSettings.ShipViewPrefab);

            ShipView instance = shipViewSettings.ShipViewPrefab.
                InstantiateAndGetComponent<ShipView>(worldSettings.WorldGameObject.transform);

            Contract.IsNotNull(instance, $"Tried to spawn new {nameof(ShipView)} " +
                $"but prefab did not contain the component");

            instance.Construct();

            shipViews.Add(instance);
        }

        public void DespawnShipView(ShipView shipView)
        {
            Contract.IsNotNull(shipView);

            bool contained = shipViews.Remove(shipView);

            Contract.IsTrue(contained, $"Tried to remove {nameof(ShipView)} but it was not even " +
                $"added at {nameof(ShipViewManager)}");

            shipView.gameObject.Destroy();
        }

        public ShipView GetShipView()
        {
            return shipViews[0];
        }
    }
}
