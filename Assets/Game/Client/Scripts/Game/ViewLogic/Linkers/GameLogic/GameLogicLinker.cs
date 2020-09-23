using System;
using Juce.Utils.Contracts;
using Juce.Core.Logic;
using Juce.Core.ViewLogic;
using Game.Shared;
using Game.Shared.Messages;

namespace Game.Client.ViewLogic
{
    public class GameLogicLinker : ILinker
    {
        private readonly GameLogicActions actions;
        private readonly ILogicBridge<Message<MessageType>> logicBridge;

        public GameLogicLinker(GameLogicActions actions, ILogicBridge<Message<MessageType>> logicBridge)
        {
            Contract.IsNotNull(actions);
            Contract.IsNotNull(logicBridge);

            this.actions = actions;
            this.logicBridge = logicBridge;

            Link();
        }

        private void Link()
        {
            logicBridge.OnReceived += (Message<MessageType> message) =>
            {
                switch(message.Type)
                {
                    case MessageType.MatchSetup:
                        {
                            actions.MatchSetup.Invoke();
                        }
                        break;

                    case MessageType.MatchStart:
                        {
                            actions.MatchStart.Invoke();
                        }
                        break;

                    case MessageType.MatchEnded:
                        {
                            actions.MatchEnded.Invoke();
                        }
                        break;

                    case MessageType.SpawnMapSection:
                        {
                            SpawnMapSectionMessage cMessage = message as SpawnMapSectionMessage;

                            actions.SpawnMapSection.Invoke(cMessage.MapSection);

                        }
                        break;

                    case MessageType.ShipDestroyed:
                        {
                            actions.ShipDestroyed.Invoke();
                        }
                        break;

                    default:
                        {
                            throw new NotImplementedException($"{nameof(message)} message not " +
                                $"implemented on {nameof(GameLogicLinker)}");
                        }
                }
            };
        }

        public void CleanUp()
        {
           
        }
    }
}
