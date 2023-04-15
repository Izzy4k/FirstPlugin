using CommandSystem;
using System;
using Exiled.API.Features;

namespace FirstPlugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public sealed class Create : ICommand
    {
        public string Command => "create";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Создает item в зависимости от очков";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var target = Player.Get((sender as CommandSender)?.SenderId);

            if (target is null)
            {
                response = "Игрок не найден!";
                return false;
            }

            if (TutorialPlugin.TutorialPlugin.SCPController.IsSCP(target))
            {
                TutorialPlugin.TutorialPlugin.CreateController.StartCreate(target);

                response = "Игрок использовал команду!";
                return true;
            }

            response = "Команда недоступна!";
            return false;
        }
    }
}
