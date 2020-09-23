using System;

namespace Game.Shared
{
    public enum MessageType
    {
        // Shared
        MatchSetup,
        MatchStart,
        MatchEnded,
        ShipDestroyed,

        // View
        ShipCollided,
        
        // Sections
        MapSectionRequest,
        SpawnMapSection,

        // Cheats
        SetGodModeCheat,
    }
}
