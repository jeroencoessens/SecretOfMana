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

    public override void Behaviour()
    {
        // Heal all characters ( 3 HP per click ), max 300HP per character
        foreach (var character in GameManager.CharManager.CharacterList)
        {
            if (character.HealthPoints < 300)
                character.HealthPoints += 3;
            else
                character.HealthPoints = 300;
        }
    }
}
