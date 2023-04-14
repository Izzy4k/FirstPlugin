using PlayerRoles;
using System;
using System.Collections.Generic;
using Exiled.API.Features;
using UnityEngine;


namespace FirstPlugin.Features
{
    public class SCPController
    {
        public Dictionary<Player, int> Snapshots { get; } = new Dictionary<Player, int>();

        public bool IsSCP(Player player)
        {
            return Snapshots.ContainsKey(player);
        }

        public void SetSCP(Player player)
        {
            Snapshots.Add(player, 0);

            try
            {
                player.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.ClassD, RoleChangeReason.None);
                player.Health = 500;
                player.Scale = new Vector3(1.5f, 0.5f, 0.5f);
                player.Broadcast(6, "Теперь ты SCP-1956");
            }
            catch (Exception e)
            {
                Log.Error($"Error {e.Message}");
            }
        }

        public void DeleteSCP(Player player)
        {
            Snapshots.Remove(player);
            DefaultScale(player);
        }

        private void DefaultScale(Player player)
        {
            player.Scale = new Vector3(1f, 1f, 1f);
        }
    }
}
