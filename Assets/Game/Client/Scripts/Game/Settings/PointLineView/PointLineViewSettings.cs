using System;
using UnityEngine;
using Juce.Core.Animation2D;
using Game.Client.View;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "PointLineViewSettings", menuName = "SampleGame/Client/Settings/PointLineViewSettings", order = 1)]
    public class PointLineViewSettings : ScriptableObject
    {
        [Header("Values")]
        [SerializeField] private float startingDistance = default;
        [SerializeField] private float distanceBetweenPointLines = default;
        [SerializeField] private float spawnOffsetFromShip = default;
        [SerializeField] private float despawnOffsetFromShip = default;

        [Header("Data")]
        [SerializeField] private PointLineView pointLineViewPrefab = default;

        public float StartingDistance => startingDistance;
        public float DistanceBetweenPointLines => distanceBetweenPointLines;
        public float SpawnOffsetFromShip => spawnOffsetFromShip;
        public float DespawnOffsetFromShip => despawnOffsetFromShip;
        public PointLineView PointLineViewPrefab => pointLineViewPrefab;
    }
}
