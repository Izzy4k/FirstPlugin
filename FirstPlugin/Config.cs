using Exiled.API.Interfaces;
using System.ComponentModel;

namespace TutorialPlugin
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Устанавливает сообщение для тех, кто присоединяется к серверу. {players} будет заменено на имя игрока.")]
        public string JoinedMessage { get; set; } = "{player} присоединился к серверу!!";

        [Description("Устанавливает сообщение для тех, кто покидает сервер. {players} будет заменено на имя игрока.")]
        public string LeftMessage { get; set; } = "{player} has left the server.";

        [Description("Устанавливает сообщение при запуске раунда.")]
        public string RoundStartMessage { get; set; } = "Приготовьтесь!";

        public bool Debug { get; set; } = true;
    }
}