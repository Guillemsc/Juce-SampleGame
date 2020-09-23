using System;

namespace Game.Client.ViewLogic
{
    public class GameLogicActions
    {
        public IMatchSetupAction MatchSetup { get; }
        public IMatchStartAction MatchStart { get; }
        public IMatchEndedAction MatchEnded { get; }
        public ISpawnMapSectionAction SpawnMapSection { get; }
        public IShipDestroyedAction ShipDestroyed { get; }

        public GameLogicActions(
            IMatchSetupAction matchSetup,
            IMatchStartAction matchStart,
            IMatchEndedAction matchEnded,
            ISpawnMapSectionAction spawnMapSection,
            IShipDestroyedAction shipDestroyed
            )
        {
            MatchSetup = matchSetup;
            MatchStart = matchStart;
            MatchEnded = matchEnded;
            SpawnMapSection = spawnMapSection;
            ShipDestroyed = shipDestroyed;
        }
    }
}
