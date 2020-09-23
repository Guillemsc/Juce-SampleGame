using System;
using Juce.Core.Bootstrap;
using Juce.Core.Services;
using Game.Client.Services;

namespace SampleGame
{
    public class GameBootstrap : Bootstrap
    {
        protected override void Execute()
        {
            CheatsService cheatsService = new CheatsService();
            ServicesProvider.Instance.RegisterService(cheatsService);

            ContextLoaderService contextLoaderService = new ContextLoaderService();
            ServicesProvider.Instance.RegisterService(contextLoaderService);

            UIControlService uiControlService = new UIControlService();
            ServicesProvider.Instance.RegisterService(uiControlService);

            GameTimeService gameTimeService = new GameTimeService();
            ServicesProvider.Instance.RegisterService(gameTimeService);

            TickablesService tickablesService = new TickablesService();
            ServicesProvider.Instance.RegisterService(tickablesService);

            contextLoaderService.LoadingContextLoader.Load().ExecuteAsync();
            contextLoaderService.MetaContextLoader.Load().ExecuteAsync();
        }
    }
}
