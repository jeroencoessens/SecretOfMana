using UnityEngine;
using System.Collections;

public class Sword : Weapon
{
    // Sword is a strong close range weapon, useless at long range
    private int IncreaseAttack = 160;

	public Sword ()
	{
	    Name = "Sword";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;
	}

    public override void Behaviour()
    {
        
    }
}
