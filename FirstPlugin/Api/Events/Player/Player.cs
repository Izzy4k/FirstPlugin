using Exiled.Events.EventArgs.Player;
using PlayerAPI = Exiled.API.Features.Player;

namespace FirstPlugin.Api.Events
{
    public sealed class Player
    {
        public delegate void PlayerJoinHandler(PlayerAPI player);

        public static event PlayerJoinHandler OnPlayerJoined;

        public delegate void PlayerLeftHandler(PlayerAPI player);

        public static event PlayerLeftHandler OnPlayerLeft;

        public delegate void PlayerDeath(PlayerAPI player);

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
