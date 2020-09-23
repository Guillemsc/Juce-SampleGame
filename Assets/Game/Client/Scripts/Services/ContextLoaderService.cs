using System;
using Game.Client.Contexts;
using Juce.Core.Contexts;
using Juce.Core.Service;

namespace Game.Client.Services
{
    public class ContextLoaderService : IService
    {
        private readonly IContextLoader loadingContextLoader = new LoadingContextLoader();
        private readonly IContextLoader metaContextLoader = new MetaContextLoader();
        private readonly IContextLoader gameContextLoader = new GameContextLoader();

        public IContextLoader LoadingContextLoader => loadingContextLoader;
        public IContextLoader MetaContextLoader => metaContextLoader;
        public IContextLoader GameContextLoader => gameContextLoader;

        public void Init()
        {

        }

        public void CleanUp()
        {

        }
    }
}
