using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;

namespace TutorialPlugin.Handlers
{
    public class Player
    {
        private readonly string player = "{player}";

        public void onLeft(LeftEventArgs args)
        {
            var message = TutorialPlugin.Instance.Config.LeftMessage.Replace(player, args.Player.Nickname);
            Map.Broadcast(6,message);
        }
    
        public void onVerified(VerifiedEventArgs args)
        {
            string temp = $"{player} очередной хороший человек на сервере!";
            var message = temp.Replace(player, args.Player.Nickname);
             Map.Broadcast(6, message);
        }
        public void onDied(DiedEventArgs args)
        {
            TutorialPlugin.SCPController.deleteSCP(args.Player);
        }
    }
}
