using System;
using UnityEngine;
using Juce.Utils.Contracts;
using Juce.Core.ViewLogic;
using Juce.Core.Tickable;

namespace Game.Client.ViewLogic
{
    public class PlayerInputLinker : ILinker
    {
        private readonly PlayerInputActions actions;
        private readonly UserInput userInput;

        public PlayerInputLinker(PlayerInputActions actions, UserInput userInput)
        {
            Contract.IsNotNull(actions);
            Contract.IsNotNull(userInput);

            this.actions = actions;
            this.userInput = userInput;

            Link();
        }

        private void Link()
        {
            userInput.OnDirectionTrigger += () =>
            {
                actions.DirectionTrigger.Invoke();
            };
        }

        public void CleanUp()
        {
           
        }
    }
}
