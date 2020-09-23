using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Juce.Core.Contexts;
using Juce.Core.Scenes;

namespace Game.Client.Contexts
{
    public class GameContextLoader : IContextLoader
    {
        private readonly ScenesContext scenesContext;

        public GameContextLoader()
        {
            List<string> scenesToLoad = new List<string>();
            scenesToLoad.Add("GameScene");

            scenesContext = new ScenesContext(scenesToLoad);
        }

        public Task Load()
        {
            return scenesContext.Load();
        }

        public Task Unload()
        {
            return scenesContext.Unload();
        }
    }
}
