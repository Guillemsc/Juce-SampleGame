using System;
using UnityEngine;
using Game.Client.View;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "PointsNumberViewSettings", menuName = "SampleGame/Client/Settings/PointsNumberViewSettings", order = 1)]
    public class PointsNumberViewSettings : ScriptableObject
    {
        [Header("Values")]
        [SerializeField] private Vector2 positionOffset = default;

        [Header("Data")]
        [SerializeField] private PointsNumberView pointsNumberViewPrefab = default;

        public Vector2 PositionOffset => positionOffset;
        public PointsNumberView PointsNumberViewPrefab => pointsNumberViewPrefab;
    }
}
