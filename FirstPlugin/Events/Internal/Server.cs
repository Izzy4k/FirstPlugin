using Exiled.API.Features;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace TutorialPlugin.Events
{
     class Server
    {
        [PluginEvent(ServerEventType.WaitingForPlayers)]
        public void OnWaitingForPlayers()
        {
            Log.Info("I love my dog!");
        }

        [PluginEvent(ServerEventType.RoundStart)]
        public void OnRoundStarted()
        {
            Map.Broadcast(10, "Начало раунда!");
        }
    }
}
