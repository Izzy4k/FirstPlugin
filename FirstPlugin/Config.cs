using Exiled.API.Interfaces;

namespace TutorialPlugin
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = true;
    }
}