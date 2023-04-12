using CommandSystem;
using PluginAPI.Core;
using System;


namespace FirstPlugin.Comands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SCPCommand : ICommand
    {
        public string Command => "scp1956";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Спавнит игрока с указанным айди за уменьшенную и уплотненную дшку";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var target = arguments.Count > 0 && int.TryParse(arguments.At(0), out var targetId)
                  ? Player.Get(targetId)
                  : Player.Get((sender as CommandSender)?.SenderId);
            if(target == null)
            {
                response = "Игрок не найден!";
                return false;
            }
        }
    }
}
