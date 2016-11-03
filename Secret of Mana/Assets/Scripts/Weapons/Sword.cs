using UnityEngine;
using System.Collections;

public class Sword : Weapon
{
    private int IncreaseAttack = 60;

	public Sword ()
	{
	    Name = "Sword";
        AttackBonus = IncreaseAttack;
        ItemTypeMember = ItemType.Weapon;
	}
}
