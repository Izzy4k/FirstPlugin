using System;   
using CommandSystem;
using RemoteAdmin;
namespace TutorialPlugin.Comands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class FirstCommand : ICommand
    {
        public string Command { get; } = "Temp";

        public string[] Aliases { get; } = {"Nigga" };


        public string Description { get; } = "Command that says 'Hello Nigga!'.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(sender is PlayerCommandSender playerCommandSender)
            {
                response = $"Hello {playerCommandSender.Nickname}";
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
