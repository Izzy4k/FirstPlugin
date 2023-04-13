using CommandSystem;
using Exiled.API.Features;
using System;

namespace FirstPlugin.Comands
{
    [CommandHandler(typeof(ClientCommandHandler))]
   public class ApartCommand : ICommand
    {
        public string Command { get; } = "apart";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "При использовании команды, " +
            "предмет в его руках удаляется и в зависимости от качества предмета добавляется какое то количество очков создания.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            
                var target = Player.Get((sender as CommandSender)?.SenderId);
                if (target == null)
                {
                    response = "Игрок не найден!";
                    return false;
                }
                if (TutorialPlugin.TutorialPlugin.SCPController.IsSCP(target))
                {
                    TutorialPlugin.TutorialPlugin.SCPController.startApart(target);
                    response = "Гей использовал команду";
                    return true;
                }
                response = "Недоступная команда!";
                return false;
            }
            
            }
}
