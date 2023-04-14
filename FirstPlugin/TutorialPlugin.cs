using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using FirstPlugin.Features;
using ServerAPI = Exiled.Events.Handlers.Server;
using PlayerAPI = Exiled.Events.Handlers.Player;
using FirstPlugin.Api.Events;

namespace TutorialPlugin
{
    public class TutorialPlugin : Plugin<Config>
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
            EventPlayer.OnPlayerJoined += player.OnPlayerJoined;
            EventPlayer.OnPlayerLeft += player.OnPlayerLeft;
            EventPlayer.OnPlayerDeath += player.OnPlayerDeath;
        }

        private void RegisterPlayerApi()
        {
            PlayerAPI.Verified += EventPlayer.InvokePlayerJoin;
            PlayerAPI.Left += EventPlayer.InvokePlayerLeft;
            PlayerAPI.Died += EventPlayer.InvokePlayerDeath;
        }

        private void UnRegisterPlayerEvent()
        {
            EventPlayer.OnPlayerJoined -= player.OnPlayerJoined;
            EventPlayer.OnPlayerLeft -= player.OnPlayerLeft;
            EventPlayer.OnPlayerDeath -= player.OnPlayerDeath;
        }

        private void UnRegisterPlayerApi()
        {
            PlayerAPI.Verified -= EventPlayer.InvokePlayerJoin;
            PlayerAPI.Left -= EventPlayer.InvokePlayerLeft;
            PlayerAPI.Died -= EventPlayer.InvokePlayerDeath;
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