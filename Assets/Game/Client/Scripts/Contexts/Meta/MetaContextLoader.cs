using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Juce.Core.Contexts;
using Juce.Core.Scenes;

namespace Game.Client.Contexts
{
    public class MetaContextLoader : IContextLoader
    {
        private readonly ScenesContext scenesContext;

        public MetaContextLoader()
        {
            List<string> scenesToLoad = new List<string>();
            scenesToLoad.Add("MetaScene");

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
