using UnityEngine;
using System.Collections;

public class Bow : Weapon {

    // The bow is string long range weapon, useless at close range
    private int IncreaseAttack = 25;
    
    public Bow()
    {
        Name = "Bow";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;
    }
}
