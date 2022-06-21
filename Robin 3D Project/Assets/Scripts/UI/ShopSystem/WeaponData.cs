using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponData
{
    public static void SaveBowUpgradeData(Weapons type, int attack, int upgrade)
    {
        PlayerPrefs.SetInt(nameof(type) + "Attack", attack);
        PlayerPrefs.SetInt(nameof(type) + "Upgrade", upgrade);
    }

    public static void SaveBowBoughtProperty(Weapons type, bool isBought)
    {
        if (isBought)
        {
            PlayerPrefs.SetInt(nameof(type) + "Bought", 1);
        }
    }

    public static void SetEquipedStatus(Weapons type, bool isEquiped)
    {
        if (isEquiped)
        {
            PlayerPrefs.SetInt(nameof(type) + "Equip", 1);
            return;
        }

        PlayerPrefs.SetInt(nameof(type) + "Equip", 0);
    }

    public static int LoadUpgradeData(Weapons type)
    {
        return PlayerPrefs.GetInt(nameof(type) + "Upgrade", 0);
    }

    public static int LoadAttackData(Weapons type)
    {
        return PlayerPrefs.GetInt(nameof(type) + "Attack", 20);
    }

    public static bool isBought(Weapons type)
    {
        return PlayerPrefs.GetInt(nameof(type) + "Bought", 0) == 1;
    }

    public static bool isEquiped(Weapons type)
    {
        return PlayerPrefs.GetInt(nameof(type) + "Equip", 0) == 1;
    }
}
