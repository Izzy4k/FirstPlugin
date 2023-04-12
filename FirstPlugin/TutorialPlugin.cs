using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using FirstPlugin.Features;

namespace TutorialPlugin
{
    public class TutorialPlugin : Plugin<Config>
    {
        private static readonly Lazy<TutorialPlugin> LazyInstance = new Lazy<TutorialPlugin>(() => new TutorialPlugin());
        public static TutorialPlugin Instance { get { return LazyInstance.Value; } }

        private static readonly Lazy<SCPController> LazySCPController = new Lazy<SCPController>(() => new SCPController());
        public static SCPController SCPController { get { return LazySCPController.Value; } }
        public override PluginPriority Priority => PluginPriority.Medium;

        private Handlers.Player player;
        private Handlers.Server server;
        private TutorialPlugin() { }

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();
            Server.WaitingForPlayers += server.onWaitingForPlayers;
            Server.RoundStarted += server.onRoundStarted;
            Player.Verified += player.onVerified;
            Player.Left += player.onLeft;
            Player.Died += player.onDied;
        }
        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= server.onWaitingForPlayers;
            Server.RoundStarted -= server.onRoundStarted;
            Player.Left -= player.onLeft;
            Player.Verified -= player.onVerified;
            Player.Died -= player.onDied;
            player = null;
            server = null;
        }
    }
}