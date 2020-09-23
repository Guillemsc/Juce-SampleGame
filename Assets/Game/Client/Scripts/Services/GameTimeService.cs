using System;
using Juce.Core.Service;
using Juce.Core.Time;

namespace Game.Client.Services
{
    public class GameTimeService : IUpdatableService
    {
        private readonly TickableTimeContext unscaledTimeContext = new TickableTimeContext();
        private readonly TickableTimeContext scaledTimeContext = new TickableTimeContext();

        public TickableTimeContext UnscaledTimeContext => unscaledTimeContext;
        public TickableTimeContext ScaledTimeContext => scaledTimeContext;

        public void Init()
        {
          
        }

        public void Update()
        {
            TickTimers();
        }

        public void CleanUp()
        {

        }

        private void TickTimers()
        {
            float deltaTime = UnityEngine.Time.deltaTime;

            unscaledTimeContext.Tick(deltaTime);
            scaledTimeContext.Tick(deltaTime);
        }
    }
}
