using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class WorldSettings
    {
        [SerializeField] private GameObject worldGameObject = default;

        public GameObject WorldGameObject => worldGameObject;
    }
}
