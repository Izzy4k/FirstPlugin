using Exiled.API.Features;

namespace TutorialPlugin.Handlers
{
     class Server
    {
        public void onWaitingForPlayers()
        {
            Log.Info("I love my dog!");
        }
        public void onRoundStarted()
        {
            Map.Broadcast(10, TutorialPlugin.Instance.Config.RoundStartMessage);
        }
    }
}
