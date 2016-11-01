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
}
