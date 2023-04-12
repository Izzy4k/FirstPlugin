using Exiled.API.Features;

namespace TutorialPlugin.Handlers
{
     class Server
    {
        public void onWaitingForPlayers()
        {
            Log.Info("Waiting for players...");
        }
        public void onRoundStarted()
        {
            Map.Broadcast(10, TutorialPlugin.Instance.Config.RoundStartMessage);
        }
    }
}
