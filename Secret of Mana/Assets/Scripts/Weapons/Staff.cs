using UnityEngine;
using System.Collections;

public class Staff : Weapon {

    private int IncreaseAttack = 0;

    public Staff()
    {
        Name = "Staff";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;
    }
}
