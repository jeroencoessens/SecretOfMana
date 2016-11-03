using UnityEngine;
using System.Collections;

public class Staff : Weapon {

    // The staff grants healing, it doesn't provide damage
    private int IncreaseAttack = 0;

    public Staff()
    {
        Name = "Staff";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;
    }
}
