using System;
using System.Threading.Tasks;
using Juce.Utils.Contracts;
using Juce.Core.Sequencing;
using Game.Client.Managers;
using Game.Client.View;

namespace Game.Client.ViewLogic
{
    public class MoveShipViewToOffsetInstruction : AsyncInstruction
    {
        private readonly ShipViewManager shipViewManager;

        public MoveShipViewToOffsetInstruction(ShipViewManager shipViewManager)
        {
            Contract.IsNotNull(shipViewManager);

            this.shipViewManager = shipViewManager;
        }

        protected override async Task OnAsyncStart()
        {
            //ShipView shipView = shipViewManager.GetShipView();

            //Sequence sequence = DOTween.Sequence();

            //float startingPosY = shipView.transform.position.y;
            //sequence.Append(shipView.transform.DOMoveY(startingPosY + 0.5f, 1).SetEase(Ease.InQuad));

            //sequence.Play();

            //await sequence.AsyncWaitForCompletion();
        }
    }
}
