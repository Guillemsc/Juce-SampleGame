using System;
using UnityEngine;

namespace Game.Client.Settings
{
    [CreateAssetMenu(fileName = "ShipViewMovementSettings", menuName = "SampleGame/Client/Settings/ShipViewMovementSettings", order = 1)]
    public class ShipViewMovementSettings : ScriptableObject
    {
        [SerializeField] private float forwardAcceleration = default;
        [SerializeField] private float forwardSpeed = default;

        [SerializeField] private float steeringSpeed = default;
        [SerializeField] [Range(0, 360)] private float maxSteeringAngle= default;

        public float ForwardAcceleration => forwardAcceleration;
        public float ForwardSpeed => forwardSpeed;
        public float SteeringSpeed => steeringSpeed;
        public float MaxSteeringAngle => maxSteeringAngle;
    }
}
