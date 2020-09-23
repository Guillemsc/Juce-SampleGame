using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Client.View;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "MapSectionsSettings", menuName = "SampleGame/Client/Settings/MapSectionsSettings", order = 1)]
    public class MapSectionsSettings : ScriptableObject
    {
        [Header("Values")]
        [SerializeField] private float startingDistance = default;
        [SerializeField] private float distanceBetweenSections = default;
        [SerializeField] private float spawnOffsetFromShip = default;
        [SerializeField] private float despawnOffsetFromShip = default;

        [Header("Data")]
        [SerializeField] private List<MapSectionView> mapSectionsPrefabs = default;

        public float StartingDistance => startingDistance;
        public float DistanceBetweenSections => distanceBetweenSections;
        public float SpawnOffsetFromShip => spawnOffsetFromShip;
        public float DespawnOffsetFromShip => despawnOffsetFromShip;
        public IReadOnlyList<MapSectionView> MapSectionsPrefabs => mapSectionsPrefabs;
    }
}
