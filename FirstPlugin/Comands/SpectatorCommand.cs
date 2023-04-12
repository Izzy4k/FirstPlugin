using CommandSystem;
using PlayerRoles;
using RemoteAdmin;
using System;


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
                playerCommandSender.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.Spectator, RoleChangeReason.None);
                response = "Yes";
                return false;
            }
            else
            {
                response = "Hello Nigga";
                return true;
            }
        }
    }
}
