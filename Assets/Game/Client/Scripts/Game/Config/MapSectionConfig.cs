using System;
using UnityEngine;
using Game.Shared.Config;

namespace Game.Client.Config
{
    [CreateAssetMenu(fileName = "MapSectionConfig", menuName = "SampleGame/Client/Settings/MapSectionConfig", order = 1)]
    public class MapSectionConfig : ScriptableObject, IMapSectionConfig
    {
        [SerializeField] private string sectionID = default;

        public string SectionID => sectionID;
    }
}
