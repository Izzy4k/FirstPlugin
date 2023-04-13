using CommandSystem;
using PlayerRoles;
using RemoteAdmin;
using System;
using Exiled.API.Features;


namespace FirstPlugin.Comands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class SpectatorCommand : ICommand
    {
        public string Command { get; } = "Spectator";

        public string[] Aliases { get; } = { ".Spectator" };

        public string Description{ get;} = "Сommand turns a person into spectators";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender playerCommandSender)
            {
                var target = Player.Get((playerCommandSender)?.SenderId);
                playerCommandSender.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.Spectator, RoleChangeReason.None);
                TutorialPlugin.TutorialPlugin.SCPController.deleteSCP(target);
                response = "Player is Spectator";
                return false;
            }
            else
            {
                response = string.Empty;
                return true;
            }
        }
    }
}
