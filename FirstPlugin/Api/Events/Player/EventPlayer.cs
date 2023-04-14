using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;

namespace FirstPlugin.Api.Events
{
    public class EventPlayer
    {
        public delegate void PlayerJoinHandler(Player player);

        public static event PlayerJoinHandler OnPlayerJoined;

        public delegate void PlayerLeftHandler(Player player);

        public static event PlayerLeftHandler OnPlayerLeft;

        public delegate void PlayerDeath(Player player);

        public static event PlayerDeath OnPlayerDeath;

        public static void InvokePlayerJoin(VerifiedEventArgs args)
        {
            OnPlayerJoined?.Invoke(args.Player);
        }

        public static void InvokePlayerLeft(LeftEventArgs args)
        {
            OnPlayerLeft?.Invoke(args.Player);
        }

        public static void InvokePlayerDeath(DiedEventArgs args)
        {
            OnPlayerDeath?.Invoke(args.Player);
        }
    }
}
