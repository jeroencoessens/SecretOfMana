using UnityEngine;
using System.Collections;

public abstract class Item
{
    // Item types
    public enum ItemType
    {
        Weapon,
        Armor
    }

    public ItemType ItemTypeMember;
    public string Name = "Item";

}
