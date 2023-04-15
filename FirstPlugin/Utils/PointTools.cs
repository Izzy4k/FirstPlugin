
namespace FirstPlugin.Utils
{
   public static class PointTools
    {
        public static int GetPoint(ItemType item)
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
