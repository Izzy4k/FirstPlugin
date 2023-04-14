using System;
using System.Collections.Generic;
using Exiled.API.Features;
using FirstPlugin.Utils;
using Exiled.API.Features.Pickups;
using UnityEngine;

namespace FirstPlugin.Features
{
    public class CreateController
    {

        private Dictionary<Player, int> SnapShots = TutorialPlugin.TutorialPlugin.SCPController.Snapshots;

        public void StartCreate(Player player)
        {
            if (IsPoint(player))
            {
                var vector = GetSpawnPosition(player);

                var message = string.Empty;

                var list = GetItems(player);

                foreach (var item in list)
                {
                    CreateItem(item, vector);
                }

                if (list.Count == 1)
                {
                    message = "Поздравляю вы истратили все очки. Где-то заспавнился предмет!";
                }

                else if (list.Count > 1)
                {
                    message = "Поздравляю вы истратили все очки. Где-то заспавнились предметы!";
                }

                else
                {
                    message = "Упс. Очков видимо не хватило...";
                }

                player.Broadcast(6, message);
            }

            else
            {
                player.Broadcast(6, "У вас нет баллов.");
            }
        }

        private void CreateItem(ItemType type, Vector3 vector)
        {
            Pickup.CreateAndSpawn(type, vector, default);
        }

        private Vector3 GetSpawnPosition(Player player)
        {
            var playerPos = player.Position;

            float x = UnityEngine.Random.Range(-1, 1);
            float z = UnityEngine.Random.Range(-1, 1);

            var offset = new Vector3(x, playerPos.y, z);

            return playerPos + offset;
        }

        private List<ItemType> GetItems(Player player)
        {
            ItemType[] itemTypes = (ItemType[])Enum.GetValues(typeof(ItemType));

            var items = new List<ItemType>();

            while (SnapShots[player] > 0)
            {
                var randomItemType = itemTypes[UnityEngine.Random.Range(0, itemTypes.Length)];
                var point = PointTools.GetPoint(randomItemType);
                if (SnapShots[player] > point)
                {
                    items.Add(randomItemType);
                    SnapShots[player] -= point;
                }

                else
                {
                    SnapShots[player] -= 10;
                }
            }

            return items;
        }
        private bool IsPoint(Player player)
        {
            if (SnapShots[player] <= 0) return false;

            return true;
        }
    }
}
