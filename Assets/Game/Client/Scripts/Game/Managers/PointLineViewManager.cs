using System;
using System.Collections.Generic;
using Juce.Utils.Contracts;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.Managers
{
    public class PointLineViewManager
    {
        private readonly WorldSettings worldSettings;
        private readonly PointLineViewSettings pointLineViewSettings;

        private readonly List<PointLineView> pointLineViews = new List<PointLineView>();

        public IReadOnlyList<PointLineView> SpawnedPointLinesView => pointLineViews;

        public PointLineViewManager(WorldSettings worldSettings, PointLineViewSettings pointLineViewSettings)
        {
            Contract.IsNotNull(worldSettings);
            Contract.IsNotNull(pointLineViewSettings);

            this.worldSettings = worldSettings;
            this.pointLineViewSettings = pointLineViewSettings;
        }

        public PointLineView SpawnPointLineView()
        {
            Contract.IsNotNull(pointLineViewSettings.PointLineViewPrefab);

            PointLineView instance = pointLineViewSettings.PointLineViewPrefab.gameObject.
                InstantiateAndGetComponent<PointLineView>(worldSettings.WorldGameObject.transform);

            Contract.IsNotNull(instance, $"Tried to spawn new {nameof(PointLineView)} " +
                $"but prefab did not contain the component");

            pointLineViews.Add(instance);

            return instance;
        }

        public void DespawnPointLineView(PointLineView pointsLineView)
        {
            Contract.IsNotNull(pointsLineView);

            bool contained = pointLineViews.Remove(pointsLineView);

            Contract.IsTrue(contained, $"Tried to remove {nameof(PointLineView)} but it was not even " +
                $"added at {nameof(PointLineViewManager)}");

            pointsLineView.gameObject.Destroy();
        }
    }
}
