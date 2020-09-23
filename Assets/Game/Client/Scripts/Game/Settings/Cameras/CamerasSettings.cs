using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [System.Serializable]
    public class CamerasSettings
    {
        [SerializeField] private Camera shipViewCamera = default;
        [SerializeField] private Cinemachine.CinemachineVirtualCamera shipViewVirtualCamera = default;

        public Camera ShipViewCamera => shipViewCamera;
        public Cinemachine.CinemachineVirtualCamera ShipViewVirtualCamera => shipViewVirtualCamera;
    }
}
