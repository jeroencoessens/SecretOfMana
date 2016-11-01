using UnityEngine;
using System.Collections;

public abstract class Character {

    // Character stats ( Default )
    public string Name = "Default Character";

    public int HealthPoints = 100;

    public int Level = 1;

    public Weapon CharacterWeapon;

    public Armor CharacterArmor;

    public int ManaPoints = 10;

    public int AttackStat = 250;

    public int DefenseStat = 250;

    public class PlayerCharacter : Character
    {
        
    }

    public class EnemyCharacter : Character
    {

    }
}
