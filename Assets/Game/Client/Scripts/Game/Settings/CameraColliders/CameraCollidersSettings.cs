using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "CameraCollidersSettings", menuName = "SampleGame/Client/Settings/CameraCollidersSettings", order = 1)]
    public class CameraCollidersSettings : ScriptableObject
    {
        [Header("Values")]
        [SerializeField] [Min(0)] private float offset = default;

        [Header("Data")]
        [SerializeField] private GameObject cameraColliderPrefab;

        public float Offset => offset;
        public GameObject CameraColliderPrefab => cameraColliderPrefab;
    }
}
