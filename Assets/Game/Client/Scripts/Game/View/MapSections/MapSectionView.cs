using System;
using UnityEngine;
using Game.Client.Config;

namespace Game.Client.View
{
    public class MapSectionView : MonoBehaviour
    {
        [SerializeField] private MapSectionConfig mapSectionConfig = default;
        [SerializeField] private Transform start = default;
        [SerializeField] private Transform end = default;

        public MapSectionConfig MapSectionConfig => mapSectionConfig;
        public Transform Start => start;
        public Transform End => end;
    }
}
