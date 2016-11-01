using UnityEngine;
using System.Collections;

public abstract class Item {

    public enum ItemType
    {
        Collectable,
        Weapon
    }

    public ItemType ItemTypeMember;
}
