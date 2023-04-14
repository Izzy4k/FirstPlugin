using CommandSystem;
using PlayerRoles;
using RemoteAdmin;
using System;
using Exiled.API.Features;


namespace FirstPlugin.Comands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class Spectator : ICommand
    {
        public string Command { get; } = "spectator";

        public string[] Aliases => Array.Empty<string>();

        public string Description { get; } = "Команда переводит игрока в спектатор";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender playerCommandSender)
            {
                var target = Player.Get((playerCommandSender)?.SenderId);

                playerCommandSender.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.Spectator, RoleChangeReason.None);
                TutorialPlugin.TutorialPlugin.SCPController.DeleteSCP(target);

                response = "Игрок в спектаторах.";
                return false;
            }

            else
            {
                response = "Что-то пошло не так.";
                return true;
            }
        }
    }
}
