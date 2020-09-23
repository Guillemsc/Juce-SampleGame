using System;
using Juce.Utils.Contracts;
using Juce.Utils.Random;
using Juce.Core.Logic;
using Game.Shared.Config;
using Game.Shared.Messages;
using Game.Shared.Objects;
 
namespace Game.Shared.Logic
{
    public partial class MatchLogic 
    {
        private readonly MatchLogicConfig matchLogicConfig;

        private readonly LogicBridge<Message<MessageType>> logicBridge = new LogicBridge<Message<MessageType>>();

        private readonly RandomGenerator randomGenerator = new RandomGenerator();

        public LogicBridge<Message<MessageType>> LogicBridge => logicBridge;

        public MatchLogic(MatchLogicConfig matchLogicConfig)
        {
            Contract.IsNotNull(matchLogicConfig);

            this.matchLogicConfig = matchLogicConfig;

            Link();
            LinkCheats();
        }

        public void Start()
        {
            LogicBridge.Send(new MatchSetupMessage());

            SendSpawnMapSection();

            LogicBridge.Send(new MatchStartMessage());
        }

        private void Link()
        {
            LogicBridge.OnReceived += (Message<MessageType> message) =>
            {
                switch(message.Type)
                {
                    case MessageType.ShipCollided:
                        {
                            if(GodMode)
                            {
                                return;
                            }

                            LogicBridge.Send(new ShipDestroyedMessage());
                            LogicBridge.Send(new MatchEndedMessage());
                        }
                        break;

                    case MessageType.MapSectionRequest:
                        {
                            SendSpawnMapSection();
                        }
                        break;
                }
            };
        }

        private void SendSpawnMapSection()
        {
            Contract.IsNotZero(matchLogicConfig.MapSectionsConfig.SectionsConfig.Count);

            int randomIndex = randomGenerator.GetInt(0, matchLogicConfig.MapSectionsConfig.SectionsConfig.Count);

            IMapSectionConfig mapSectionConfig = matchLogicConfig.MapSectionsConfig.SectionsConfig[randomIndex];

            MapSection mapSection = new MapSection(mapSectionConfig.SectionID);

            LogicBridge.Send(new SpawnMapSectionMessage(mapSection));
        }
    }
}
