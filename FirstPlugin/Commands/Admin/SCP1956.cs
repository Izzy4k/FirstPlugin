using CommandSystem;
using Exiled.API.Features;
using System;

namespace FirstPlugin.Comands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
   public sealed class SCP1956 : ICommand
    {
        public string Command => "scp1956";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Спавнит игрока с указанным айди за уменьшенную и уплотненную дшку";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count < 1)
            {

                response = "Неверный синтаксис! Используйте scp1956 [id]";
                return false;
            }

            var target = Player.Get(arguments.At(0));

            if (target == null)
            {
                response = "Игрок не найден!";
                return false;
            }

            if (TutorialPlugin.TutorialPlugin.SCPController.IsSCP(target))
            {
                response = "Игрок уже SCP-1956";
                return true;
            }

            TutorialPlugin.TutorialPlugin.SCPController.SetSCP(target);

            response = "Соболезную игроку";
            return true;
        }
    }
}
