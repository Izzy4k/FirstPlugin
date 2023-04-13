using CommandSystem;
using System;
using Exiled.API.Features;

namespace FirstPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class CreateCommand : ICommand
    {
        public string Command => "create";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Создает item в зависимости от очков";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var target = Player.Get((sender as CommandSender)?.SenderId);
            if(target == null)
            {
                response = "Игрок не найден";
                return false;
            }
            if (TutorialPlugin.TutorialPlugin.SCPController.IsSCP(target))
            {
                TutorialPlugin.TutorialPlugin.SCPController.startCreate(target);
                response = "Гей использовал команду";
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}
