using Exiled.API.Features;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

using PlayerAPI = Exiled.API.Features.Player;

namespace TutorialPlugin.Events
{
    public sealed class Player 
    {

        [PluginEvent(ServerEventType.PlayerLeft)]
        public void OnPlayerLeft(PlayerAPI player)
        {
            Map.Broadcast(6,$"Игрок {player.Nickname} покинул сервер.");
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        public void OnPlayerJoined(PlayerAPI player)
        {
             Map.Broadcast(6, $"Игрок {player.Nickname} присоединился к серверу.");
        }

        [PluginEvent(ServerEventType.PlayerDeath)]
        public void OnPlayerDeath(PlayerAPI player)
        {
            TutorialPlugin.SCPController.DeleteSCP(player);
        }
    }
}
