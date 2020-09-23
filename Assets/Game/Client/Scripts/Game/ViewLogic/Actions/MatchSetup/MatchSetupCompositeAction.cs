using System;

namespace Game.Client.ViewLogic
{
    public class MatchSetupCompositeAction : IMatchSetupAction
    {
        private readonly IMatchSetupAction[] composite;

        public MatchSetupCompositeAction(IMatchSetupAction[] composite)
        {
            this.composite = composite;
        }

        public void Invoke()
        {
            for(int i = 0; i < composite.Length; ++i)
            {
                composite[i].Invoke();
            }
        }
    }
}
