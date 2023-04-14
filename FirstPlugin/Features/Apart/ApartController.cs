using Exiled.API.Features.Items;
using Exiled.API.Features;
using System.Collections.Generic;
using FirstPlugin.Utils;

namespace FirstPlugin.Features
{
    public class ApartController
    {
        private Dictionary<Player, int> SnapShots = TutorialPlugin.TutorialPlugin.SCPController.Snapshots;

        private bool IsHaveItem(Item item)
        {
            return item != null;
        }

        public void StartApart(Player player)
        {
            if (IsHaveItem(player.CurrentItem))
            {
                var target = DeleteItem(player);

                SnapShots[player] = SnapShots[player] + PointTools.GetPoint(target.Type);

                player.Broadcast(10, $"Предмет был успешно продан. Вы приобрели - {SnapShots[player]} баллов.");
            }

            else
            {
                player.Broadcast(10, "Нет предмета для продажи. Пожалуйста, возьмите предмет в руки для продажи.");
            }
        }

        private Item DeleteItem(Player player)
        {
            var item = player.CurrentItem;

            player.RemoveItem(item);

            return item;
        }
    }
}
