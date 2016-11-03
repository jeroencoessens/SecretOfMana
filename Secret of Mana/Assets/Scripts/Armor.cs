using UnityEngine;
using System.Collections;

public class Armor : Item {

    // Types of armor
    public enum ArmorType
    {
        Helmet,
        Chestplate,
        Pants,
        Boots
    }

    // Armor specs
    public ArmorType ArmorPiece;
    public int DefenseBonus = 0;

    public Armor(ArmorType type)
    {
        // Set to correct armor piece

        switch (type)
        {
            case ArmorType.Helmet:
                Name = "Helmet";
                break;
            case ArmorType.Chestplate:
                Name = "Chestplate";
                break;
            case ArmorType.Pants:
                Name = "Pants";
                break;
            case ArmorType.Boots:
                Name = "Boots";
                break;
        }

        ItemTypeMember = ItemType.Armor;
        ArmorPiece = type;
        UpdateDefense();
    }

    // Set correct armor specs
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
