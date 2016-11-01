using UnityEngine;
using System.Collections;

public class Armor : Item {

    public enum ArmorType
    {
        Helmet,
        Chestplate,
        Pants,
        Boots
    }

    public ArmorType ArmorPiece;

    public int DefenseBonus = 10;

    public Armor(ArmorType type)
    {
        ArmorPiece = type;
        UpdateDefense();
    }

    void UpdateDefense()
    {
        switch (ArmorPiece)
        {
            case ArmorType.Helmet:
                DefenseBonus = 60;
                break;
            case ArmorType.Chestplate:
                DefenseBonus = 120;
                break;
            case ArmorType.Pants:
                DefenseBonus = 80;
                break;
            case ArmorType.Boots:
                DefenseBonus = 40;
                break;
        }
    }
}
