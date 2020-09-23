using System;
using System.Collections.Generic;
using UnityEngine;
using Juce.Utils.Contracts;
using Juce.Core.Tickable;
using Juce.Core.Services;
using Game.Client.Settings;

namespace Game.Client.ViewLogic
{
    public class BackgroundParallaxBehaviour : Juce.Core.ViewLogic.Behaviour, ITickable
    {
        private readonly TickablesService tickableService;
        private readonly CamerasSettings cameraSettings;

        public BackgroundParallaxBehaviour(TickablesService tickableService,
            CamerasSettings cameraSettings)
        {
            Contract.IsNotNull(tickableService);
            Contract.IsNotNull(cameraSettings);

            this.tickableService = tickableService;
            this.cameraSettings = cameraSettings;
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
            
        }

        private void CheckBackgroundFill()
        {
            SpriteRenderer spriteRenderer = null;

            Vector2 containedSize = spriteRenderer.bounds.size;

            Rect cameraRect = cameraSettings.ShipViewCamera.GetWorldPositionRect();

            Rect checkingRect = new Rect(cameraRect.position, containedSize);

            if(cameraRect.Overlaps(checkingRect))
            {

            }
        }

        private IReadOnlyList<Vector2> GetAllPositionsToFill()
        {
            List<Vector2> ret = new List<Vector2>();

            SpriteRenderer spriteRenderer = null;

            Vector2 containedSize = spriteRenderer.bounds.size;

            Rect cameraRect = cameraSettings.ShipViewCamera.GetWorldPositionRect();

            float verticalPos = cameraRect.position.y;

            while(verticalPos + containedSize.y < cameraRect.yMax)
            {
                IReadOnlyList<Vector2> positions = GetAllPositionsToFillAtVerticalPos(cameraRect, verticalPos);
                ret.AddRange(positions);

                verticalPos += containedSize.y;
            }

            verticalPos = cameraRect.position.y - containedSize.y;

            while (verticalPos - containedSize.y > cameraRect.yMin)
            {
                IReadOnlyList<Vector2> positions = GetAllPositionsToFillAtVerticalPos(cameraRect, verticalPos);
                ret.AddRange(positions);

                verticalPos -= containedSize.y;
            }

            return ret;
        }

        private IReadOnlyList<Vector2> GetAllPositionsToFillAtVerticalPos(Rect cameraRect, float verticalPos)
        {
            List<Vector2> ret = new List<Vector2>();

            SpriteRenderer spriteRenderer = null;

            Vector2 containedSize = spriteRenderer.bounds.size;

            Rect checkingRect = new Rect(new Vector2(cameraRect.position.x, verticalPos), containedSize);

            while(cameraRect.Overlaps(checkingRect))
            {
                ret.Add(checkingRect.position);

                checkingRect.x -= containedSize.x;
            }

            checkingRect.position = new Vector2(cameraRect.position.x + containedSize.x, verticalPos);

            while (cameraRect.Overlaps(checkingRect))
            {
                ret.Add(checkingRect.position);

                checkingRect.x += containedSize.x;
            }

            return ret;
        }
    }
}

