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

    // for Material
    public Color Color;

    // for Starting position
    public Vector3 StartingPosition;

    public class PlayerCharacter : Character
    {
        public void Initialize()
        {
            var character = GameObject.Instantiate(Resources.Load("Prefabs/Character"), Vector3.zero, Quaternion.identity) as GameObject;
            character.gameObject.tag = Tag.ToString();
            character.name = "Character" + Tag;

            var VisualCharacter = character.GetComponent<VisualCharacter>();
            VisualCharacter.ColorForMaterial = Color;
            VisualCharacter.StartingPosition = StartingPosition;
            VisualCharacter.ThisTag = Tag;
            VisualCharacter.Initialize();
        }
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


