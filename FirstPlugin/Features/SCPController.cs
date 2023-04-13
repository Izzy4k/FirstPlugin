using PlayerRoles;
using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using UnityEngine;
using Exiled.API.Features.Pickups;

namespace FirstPlugin.Features
{
    public class SCPController
    {

        public Dictionary<Player, int> Snapshots { get; } = new Dictionary<Player, int>();


        public bool IsSCP(Player player)
        {
            return Snapshots.ContainsKey(player);
        }

        public void setSCP(Player player)
        {
            Snapshots.Add(player, 0);
            try
            {
                player.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.ClassD, RoleChangeReason.None);
                player.Health = 500;
                player.Scale = new Vector3(1.5f, 0.5f, 0.5f);
                player.Broadcast(6, "Теперь ты чOрный Таджик :((");
            } catch (Exception e)
            {
                Log.Error($"Error {e.Message}");
            }

        }
        public void deleteSCP(Player player)
        {
            Snapshots.Remove(player);
            defaultScale(player);
        }
        private Item deleteItem(Player player)
        {
            var item = player.CurrentItem;
            player.RemoveItem(item);
            return item;
        }
        private bool isHaveItem(Item item)
        {
            return item != null;
        }
        public void startApart(Player player)
        {
            if (isHaveItem(player.CurrentItem))
            {
                var target = deleteItem(player);
                Snapshots[player] = Snapshots[player] + GetPoint(target.Type);
                player.Broadcast(10, "Ты гей");
            }
            else
            {
                player.Broadcast(10, "Ты бомж! Какие тебе очки? Иди отсюда, животное.");
            }
        }

        private void defaultScale(Player player)
        {
            player.Scale = new Vector3(1f,1f, 1f);
        }
        public void startCreate(Player player)
        {
            if (IsPoint(player))
            {
                var vector = GetSpawnPosition(player);
                var message = string.Empty;
                var list = getItems(player);
                foreach (var item in list)
                {
                    createItem(item, vector);
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
                player.Broadcast(6, "Ты бомж!");
            }
        }
        private void createItem(ItemType type, Vector3 vector)
        {
            Pickup.CreateAndSpawn(type,vector,default);
        }
        private Vector3 GetSpawnPosition(Player player)
        {
            var playerPos = player.Position;
            float x = UnityEngine.Random.Range(-1, 1);
            float z = UnityEngine.Random.Range(-1, 1);
            var offset = new Vector3(x,playerPos.y, z);
            return playerPos + offset;
        }
        private List<ItemType> getItems(Player player)
        {
            ItemType[] itemTypes = (ItemType[])Enum.GetValues(typeof(ItemType));
            var items = new List<ItemType>();
            while (Snapshots[player] > 0)
            {
                var randomItemType = itemTypes[UnityEngine.Random.Range(0, itemTypes.Length)];
                var point = GetPoint(randomItemType);
                if (Snapshots[player] > point)
                {
                    items.Add(randomItemType);
                    Snapshots[player] -= point;
                }
                else
                {
                    Snapshots[player] -=10;
                }
            }
            return items;
        }
        
        private bool IsPoint(Player player)
        {
            if (Snapshots[player] <= 0) return false;
            return true;
        }
        private int GetPoint(ItemType item)
        {
            switch (item)
            {
                case ItemType.SCP268:
                    return 100;
                case ItemType.Medkit:
                    return 40;
                case ItemType.SCP500:
                case ItemType.SCP207:
                    return 100;
                case ItemType.Adrenaline:
                case ItemType.Painkillers:
                    return 50;
                case ItemType.SCP1853:
                case ItemType.SCP244a:
                case ItemType.SCP244b:
                    return 100;
                case ItemType.Ammo12gauge:
                case ItemType.Ammo556x45:
                case ItemType.Ammo44cal:
                case ItemType.Ammo762x39:
                case ItemType.Ammo9x19:
                    return 10;
                case ItemType.Flashlight:
                case ItemType.Radio:
                    return 20;
                case ItemType.MicroHID:
                    return 300;
                case ItemType.GrenadeFlash:
                case ItemType.GrenadeHE:
                    return 20;
                case ItemType.SCP018:
                    return 100;
                case ItemType.GunCOM15:
                case ItemType.GunE11SR:
                case ItemType.GunCrossvec:
                case ItemType.GunFSP9:
                case ItemType.GunLogicer:
                case ItemType.GunCOM18:
                case ItemType.GunRevolver:
                case ItemType.GunAK:
                case ItemType.GunShotgun:
                case ItemType.ParticleDisruptor:
                case ItemType.GunCom45:
                    return 50;
                case ItemType.KeycardJanitor:
                case ItemType.KeycardScientist:
                case ItemType.KeycardResearchCoordinator:
                case ItemType.KeycardZoneManager:
                case ItemType.KeycardGuard:
                case ItemType.KeycardNTFOfficer:
                case ItemType.KeycardContainmentEngineer:
                case ItemType.KeycardNTFLieutenant:
                case ItemType.KeycardNTFCommander:
                case ItemType.KeycardFacilityManager:
                case ItemType.KeycardChaosInsurgency:
                case ItemType.KeycardO5:
                    return 30;
                case ItemType.ArmorLight:
                case ItemType.ArmorCombat:
                case ItemType.ArmorHeavy:
                    return 100;
                case ItemType.SCP330:
                case ItemType.SCP2176:
                case ItemType.SCP1576:
                case ItemType.Jailbird:
                    return 50;
                default: return 0;   
            }
        }
    }
}
