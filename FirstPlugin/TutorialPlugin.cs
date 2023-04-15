using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using FirstPlugin.Features;
using ServerAPI = Exiled.Events.Handlers.Server;
using PlayerAPI = Exiled.Events.Handlers.Player;

namespace TutorialPlugin
{
    public sealed class TutorialPlugin : Plugin<Config>
    {
        private static readonly Lazy<TutorialPlugin> LazyInstance = new Lazy<TutorialPlugin>(() => new TutorialPlugin());

        public static TutorialPlugin Instance { get { return LazyInstance.Value; } }

        private static readonly Lazy<SCPController> LazySCPController = new Lazy<SCPController>(() => new SCPController());

        public static SCPController SCPController { get { return LazySCPController.Value; } }

        private static readonly Lazy<ApartController> LazyApartController = new Lazy<ApartController> (()=> new ApartController());   

        public static ApartController ApartController  => LazyApartController.Value;

        private static readonly Lazy <CreateController> LazyCreateController = new Lazy<CreateController> (() => new CreateController());

        public static CreateController CreateController => LazyCreateController.Value;

        public override PluginPriority Priority => PluginPriority.Medium;

        private Events.Player player;

        private Events.Server server;

        private TutorialPlugin() { }

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            player = new Events.Player();
            server = new Events.Server();

            ServerAPI.WaitingForPlayers += server.OnWaitingForPlayers;
            ServerAPI.RoundStarted += server.OnRoundStarted;

            RegisterPlayerApi();
            RegisterPlayerEvent();
        }

        private void RegisterPlayerEvent()
        {
            FirstPlugin.Api.Events.Player.OnPlayerJoined += player.OnPlayerJoined;
            FirstPlugin.Api.Events.Player.OnPlayerLeft += player.OnPlayerLeft;
            FirstPlugin.Api.Events.Player.OnPlayerDeath += player.OnPlayerDeath;
        }

        private void RegisterPlayerApi()
        {
            PlayerAPI.Verified += FirstPlugin.Api.Events.Player.InvokePlayerJoin;
            PlayerAPI.Left += FirstPlugin.Api.Events.Player.InvokePlayerLeft;
            PlayerAPI.Died += FirstPlugin.Api.Events.Player.InvokePlayerDeath;
        }

        private void UnRegisterPlayerEvent()
        {
            FirstPlugin.Api.Events.Player.OnPlayerJoined -= player.OnPlayerJoined;
            FirstPlugin.Api.Events.Player.OnPlayerLeft -= player.OnPlayerLeft;
            FirstPlugin.Api.Events.Player.OnPlayerDeath -= player.OnPlayerDeath;
        }

        private void UnRegisterPlayerApi()
        {
            PlayerAPI.Verified -= FirstPlugin.Api.Events.Player.InvokePlayerJoin;
            PlayerAPI.Left -= FirstPlugin.Api.Events.Player.InvokePlayerLeft;
            PlayerAPI.Died -= FirstPlugin.Api.Events.Player.InvokePlayerDeath;
        }

        public void UnRegisterEvents()
        {
            ServerAPI.WaitingForPlayers -= server.OnWaitingForPlayers;
            ServerAPI.RoundStarted -= server.OnRoundStarted;

            UnRegisterPlayerApi();
            UnRegisterPlayerEvent();

            player = null;
            server = null;
        }
    }
}