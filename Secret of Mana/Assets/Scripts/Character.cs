using UnityEngine;
using System.Collections;

public class Character {

    // Character stats ( Default )
    public string Name = "Mister Default";
    public string Role = "Peasant";

    public int HealthPoints = 100;
    public int ManaPoints = 10;

    public int Level = 1;

    public Weapon CharacterWeapon;
    public Armor CharacterArmor;

    public int AttackStat = 250;
    public int DefenseStat = 250;
    
    //Attack ( for weapon behaviour )
    public bool CanAttack = false;

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
            // Spawn character prefab
            VisualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Character"), Vector3.zero, Quaternion.identity) as GameObject;
            VisualPrefab.gameObject.tag = Tag.ToString();
            VisualPrefab.name = "Character" + Tag;

            // Set visual character correct attributes
            var VisualCharacter = VisualPrefab.GetComponent<VisualCharacter>();
            VisualCharacter.ColorForMaterial = Color;
            VisualCharacter.ThisTag = Tag;
            VisualCharacter.StartingPosition = StartingPosition;
            VisualCharacter.ThisPlayer = this;

            VisualCharacter.Initialize();
        }
    }

    public class EnemyCharacter : Character
    {
        public void Initialize()
        {
            // Spawn enemy prefab
            VisualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
            VisualPrefab.gameObject.tag = "Enemy";
            VisualPrefab.name = "Enemy" + Tag;

            // Set visual enemy correct attributes
            var VisualEnemy = VisualPrefab.GetComponent<VisualEnemy>();
            VisualEnemy.AttackStat = AttackStat;
            VisualEnemy.DefenseStat = DefenseStat;
            VisualEnemy.StartingPosition = StartingPosition;
            VisualEnemy.ThisEnemy = this;

            VisualEnemy.Initialize();
        }
    }

    // Update attack / defense stats when equipped armor
    public void UpdateAttackStat()
    {
        if (CharacterWeapon != null) AttackStat += CharacterWeapon.AttackBonus;
    }

    public void UpdateDefensStat()
    {
        if (CharacterArmor != null) DefenseStat += CharacterArmor.DefenseBonus;
    }

    // Return position of the character
    public Vector3 GetPosition()
    {
        if (VisualPrefab != null)
            return VisualPrefab.transform.position;
        else
            return Vector3.zero;
    }
}


