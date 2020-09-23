using System;
using UnityEngine;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Settings;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class ShipViewMovementBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly ShipViewMovementSettings movementSettings;

        private ShipView shipView;
        private Transform shipViewTransform;

        private float currSpeed;
        private float angleToReach;

        public ShipViewMovementBehaviour(TickablesService tickableService, ShipViewMovementSettings movementSettings)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(movementSettings);

            this.tickableService = tickableService;
            this.movementSettings = movementSettings;

            this.shipView = null;
            this.shipViewTransform = null;
        }

        protected override void OnEnable()
        {
            tickableService.AddTickable(this);
        }

        protected override void OnDisable()
        {
            tickableService.RemoveTickable(this);
        }

        public void Tick()
        {
            MoveForward();

            UpdateSteering();
        }

        public void StartMoving(ShipView shipView)
        {
            Contract.IsNotNull(shipView);

            this.shipView = shipView;
            this.shipViewTransform = shipView.transform;
        }

        public void StopMoving(ShipView shipView)
        {
            Contract.IsNotNull(shipView);

            shipView.RigidBody.velocity = Vector2.zero;

            this.shipView = null;
            this.shipViewTransform = null;
        }

        private void MoveForward()
        {
            if (shipView == null)
            {
                return;
            }

            float forwardAccelerationDt = movementSettings.ForwardAcceleration * Time.deltaTime;

            if (movementSettings.ForwardSpeed >= currSpeed)
            {
                if (currSpeed + forwardAccelerationDt < movementSettings.ForwardSpeed)
                {
                    currSpeed += forwardAccelerationDt;
                }
                else
                {
                    currSpeed = movementSettings.ForwardSpeed;
                }
            }
            else if(movementSettings.ForwardSpeed < currSpeed)
            {
                if (currSpeed - forwardAccelerationDt > movementSettings.ForwardSpeed)
                {
                    currSpeed -= forwardAccelerationDt;
                }
                else
                {
                    currSpeed = movementSettings.ForwardSpeed;
                }
            }

            Vector3 newSpeed = (shipView.transform.up * currSpeed);

            shipView.RigidBody.velocity = newSpeed;
        }

        public void SetSteeringAngleFromNormalizedValue(float value)
        {
            if(value == 0)
            {
                SetSteerAngle(0);
            }
            else if(value > 0)
            {
                float angle =  360 - (movementSettings.MaxSteeringAngle * value);

                SetSteerAngle(angle);
            }
            else
            {
                float angle = (movementSettings.MaxSteeringAngle * Mathf.Abs(value));

                SetSteerAngle(angle);
            }
        }

        public void SetSteerAngle(float angleDeg)
        {
            if (shipView == null)
            {
                return;
            }

            angleToReach = CapSteeringAngle(angleDeg);
        }

        private void UpdateSteering()
        {
            if (shipView == null)
            {
                return;
            }

            float difference = Mathf.DeltaAngle(shipViewTransform.localEulerAngles.z, angleToReach);

            float speedDt = UnityEngine.Time.deltaTime * movementSettings.SteeringSpeed;

            if (Mathf.Abs(difference) > 0)
            {
                if (difference > 0)
                {
                    shipViewTransform.localRotation *= Quaternion.Euler(0, 0, speedDt);
                }
                else
                {
                    shipViewTransform.localRotation *= Quaternion.Euler(0, 0, -speedDt);
                }
            }
        }

        private float CapSteeringAngle(float angle)
        {
            if (angle < 180)
            {
                if (angle > movementSettings.MaxSteeringAngle)
                {
                    return movementSettings.MaxSteeringAngle;
                }
            }
            else
            {
                if (angle < 360 - movementSettings.MaxSteeringAngle)
                {
                    return (360 - movementSettings.MaxSteeringAngle);
                }
            }

            return angle;
        }
    }
}
