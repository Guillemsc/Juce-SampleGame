using System;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Juce.Core.Time;
using Game.Client.Settings;
using Game.Client.ViewModels;
using Game.Client.Services;

namespace Game.Client.ViewLogic
{
    public class StartDirectionBarViewModel : InstantInstruction
    {
        private readonly DirectionBarViewModel directionBarViewModel;
        private readonly GameTimeService gameTimeService;
        private readonly DirectionBarSettings directionBarSettings;

        public StartDirectionBarViewModel(DirectionBarViewModel directionBarViewModel, GameTimeService gameTimeService,
            DirectionBarSettings directionBarSettings)
        {
            Contract.IsNotNull(directionBarViewModel);
            Contract.IsNotNull(gameTimeService);
            Contract.IsNotNull(directionBarSettings);

            this.directionBarViewModel = directionBarViewModel;
            this.gameTimeService = gameTimeService;
            this.directionBarSettings = directionBarSettings;
        }

        protected override void OnInstantStart()
        {
            directionBarViewModel.Construct(gameTimeService.ScaledTimeContext.NewTimer(), directionBarSettings);

            directionBarViewModel.CanMove = true;
        }
    }
}
