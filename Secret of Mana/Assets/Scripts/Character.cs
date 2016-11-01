using UnityEngine;
using System.Collections;

public class Character {

    // Character stats ( Default )
    public string Name = "Mister Default";

    public string Role = "Hero";

    public int HealthPoints = 100;

    public int Level = 1;

    public Weapon CharacterWeapon;

    public Armor CharacterArmor;

    public int ManaPoints = 10;

    public int AttackStat = 250;

    public int DefenseStat = 250;

    // for HUD
    public int Tag = 1;

    public class PlayerCharacter : Character
    {

    }

    public class EnemyCharacter : Character
    {

    }

    public void UpdateAttackStat()
    {
        AttackStat += CharacterWeapon.AttackBonus;
    }

    public void UpdateDefensStat()
    {
        DefenseStat += CharacterArmor.DefenseBonus;
    }
}


