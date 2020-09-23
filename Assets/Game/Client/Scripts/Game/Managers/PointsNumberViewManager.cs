using System;
using System.Collections.Generic;
using Juce.Utils.Contracts;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.Managers
{
    public class PointsNumberViewManager
    {
        private readonly WorldSpaceUISettings worldSpaceUISettings;
        private readonly PointsNumberViewSettings pointsNumberViewSettings;

        private readonly List<PointsNumberView> pointsNumberViews = new List<PointsNumberView>();

        public IReadOnlyList<PointsNumberView> SpawnedPointsNumberView => pointsNumberViews;

        public PointsNumberViewManager(WorldSpaceUISettings worldSpaceUISettings, PointsNumberViewSettings pointsNumberViewSettings)
        {
            Contract.IsNotNull(worldSpaceUISettings);
            Contract.IsNotNull(pointsNumberViewSettings);

            this.worldSpaceUISettings = worldSpaceUISettings;
            this.pointsNumberViewSettings = pointsNumberViewSettings;
        }

        public PointsNumberView SpawnPointsNumberView()
        {
            Contract.IsNotNull(pointsNumberViewSettings.PointsNumberViewPrefab);

            PointsNumberView instance = pointsNumberViewSettings.PointsNumberViewPrefab.gameObject.
                InstantiateAndGetComponent<PointsNumberView>(worldSpaceUISettings.WorldSpaceCanvas.transform);

            Contract.IsNotNull(instance, $"Tried to spawn new {nameof(PointsNumberView)} " +
                $"but prefab did not contain the component");

            pointsNumberViews.Add(instance);

            return instance;
        }

        public void DespawnPointsNumberView(PointsNumberView pointsNumberView)
        {
            Contract.IsNotNull(pointsNumberView);

            bool contained = pointsNumberViews.Remove(pointsNumberView);

            Contract.IsTrue(contained, $"Tried to remove {nameof(PointsNumberView)} but it was not even " +
                $"added at {nameof(PointsNumberViewManager)}");

            pointsNumberView.gameObject.Destroy();
        }
    }
}
