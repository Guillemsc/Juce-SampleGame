using System;
using System.Threading.Tasks;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.ViewModels;

namespace Game.Client.ViewLogic
{
    public class ShowLoseScreenViewModelInstruction : AsyncInstruction
    {
        private readonly LoseScreenViewModel loseScreenViewModel;

        public ShowLoseScreenViewModelInstruction(LoseScreenViewModel loseScreenViewModel)
        {
            Contract.IsNotNull(loseScreenViewModel);

            this.loseScreenViewModel = loseScreenViewModel;
        }

        protected override async Task OnAsyncStart()
        {
            await loseScreenViewModel.Show();
        }
    }
}
