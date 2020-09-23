using System;
using UnityEngine;
using Juce.Core.Contexts;
using Juce.Core.Services;
using Game.Client.Services;
using Game.Client.ViewLogic;

namespace Game.Client.Contexts
{
    public class GameContext : Context
    {
        [SerializeField] private GameContextReferences references = default;

        private GameDefaultEntryPoint defaultEntryPoint;

        public GameContextReferences References => references;

        protected override void InitContext()
        {
            ContextsProvider.Instance.RegisterContext(this);

            defaultEntryPoint = new GameDefaultEntryPoint();
            defaultEntryPoint.Execute();
        }

        protected override void CleanUpContext()
        {
            defaultEntryPoint.Finish();
            defaultEntryPoint.CleanUp();

            ContextsProvider.Instance.UnregisterContext(this);
        }
    }
}
