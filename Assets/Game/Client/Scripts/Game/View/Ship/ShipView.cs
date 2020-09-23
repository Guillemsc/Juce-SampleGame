using System;
using UnityEngine;
using Juce.Utils.Contracts;
using Juce.Core.Physics;
using Juce.Core.Events;
using Game.Client.Events;

namespace Game.Client.View
{
    public class ShipView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody = default;
        [SerializeField] private PhysicsCallbacks physicsCallbacks = default;

        public Rigidbody2D RigidBody => rigidBody;
        public PhysicsCallbacks PhysicsCallbacks => physicsCallbacks;

        public void Construct()
        {
            Contract.IsNotNull(rigidBody);
            Contract.IsNotNull(physicsCallbacks);

            PhysicsCallbacks.OnPhysicsTriggerEnter2D += OnShipPhysicsTriggerEnter2D;
        }

        private void OnShipPhysicsTriggerEnter2D(Collider2DData data)
        {
            EventsProvider.Instance.Invoke(new ShipViewCollidedEvent(data));
        }
    }
}
