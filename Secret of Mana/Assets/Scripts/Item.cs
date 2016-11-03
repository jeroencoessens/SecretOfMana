using UnityEngine;
using System.Collections;

public abstract class Item
{
    public enum ItemType
    {
        Collectable,
        Weapon,
        Armor
    }

    public ItemType ItemTypeMember;
    public string Name = "Item";

}
