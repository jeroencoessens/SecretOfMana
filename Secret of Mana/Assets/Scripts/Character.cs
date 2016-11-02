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

    // Visual Character
    private GameObject VisualPrefab;

    // End Game
    public bool HasDied = false;

    public class PlayerCharacter : Character
    {
        public void Initialize()
        {
            VisualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Character"), Vector3.zero, Quaternion.identity) as GameObject;
            VisualPrefab.gameObject.tag = Tag.ToString();
            VisualPrefab.name = "Character" + Tag;

            var VisualCharacter = VisualPrefab.GetComponent<VisualCharacter>();
            VisualCharacter.ColorForMaterial = Color;
            VisualCharacter.ThisTag = Tag;
            VisualCharacter.StartingPosition = StartingPosition;
            VisualCharacter.Health = HealthPoints;
            VisualCharacter.AttackStat = AttackStat;
            VisualCharacter.DefenseStat = DefenseStat;
            VisualCharacter.ThisPlayer = this;

            VisualCharacter.Initialize();
        }
    }

    public class EnemyCharacter : Character
    {
        public void Initialize()
        {
            VisualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
            VisualPrefab.gameObject.tag = "Enemy";
            VisualPrefab.name = "Enemy" + Tag;

            var VisualEnemy = VisualPrefab.GetComponent<VisualEnemy>();
            VisualEnemy.StartingPosition = StartingPosition;
            VisualEnemy.CurrentHealth = HealthPoints;
            VisualEnemy.AttackStat = AttackStat;
            VisualEnemy.DefenseStat = DefenseStat;
            VisualEnemy.ThisEnemy = this;

            VisualEnemy.Initialize();
        }
    }

    public void UpdateAttackStat()
    {
        AttackStat += CharacterWeapon.AttackBonus;
    }

    public void UpdateDefensStat()
    {
        DefenseStat += CharacterArmor.DefenseBonus;
    }

    public Vector3 GetPosition()
    {
        if (VisualPrefab != null)
            return VisualPrefab.transform.position;
        else
            return Vector3.zero;
    }
}


