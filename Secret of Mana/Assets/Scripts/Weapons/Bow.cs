using UnityEngine;
using System.Collections;

public class Bow : Weapon {

    private int IncreaseAttack = 25;
    
    public Bow()
    {
        Name = "Bow";
        AttackBonus = IncreaseAttack;
    }
}
