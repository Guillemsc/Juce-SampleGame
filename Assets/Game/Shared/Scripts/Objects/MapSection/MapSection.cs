using System;
using Juce.Core.Shared;

namespace Game.Shared.Objects
{
    public class MapSection : SharedObject
    {
        public string SectionID { get; }

        public MapSection(string sectionID)
        {
            SectionID = sectionID;
        }
    }
}
