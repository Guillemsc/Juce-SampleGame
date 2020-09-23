using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class WorldSpaceUISettings
    {
        [SerializeField] private Canvas worldSpaceCanvas = default;

        public Canvas WorldSpaceCanvas => worldSpaceCanvas;
    }
}
