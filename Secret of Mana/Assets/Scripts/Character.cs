using UnityEngine;
using System.Collections;

public class Character {

    // Character stats ( Default )
    public string Name = "Mister Default";
    public string Role = "Peasant";

    // HP & MP
    public int HealthPoints = 100;
    public int ManaPoints = 10;

    // Level, not really implemented
    public int Level = 1;

    // Items
    public Weapon CharacterWeapon;
    public Armor CharacterArmor;

    // Stats
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
    private GameObject _visualPrefab;

    // End Game
    public bool HasDied = false;

    public class PlayerCharacter : Character
    {
        public void Initialize()
        {
            // Spawn character prefab
            _visualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Character"), Vector3.zero, Quaternion.identity) as GameObject;
            if (_visualPrefab != null)
            {
                _visualPrefab.gameObject.tag = Tag.ToString();
                _visualPrefab.name = "Character" + Tag;

                // Set visual character correct attributes
                var visualCharacter = _visualPrefab.GetComponent<VisualCharacter>();
                visualCharacter.ColorForMaterial = Color;
                visualCharacter.ThisTag = Tag;
                visualCharacter.StartingPosition = StartingPosition;
                visualCharacter.ThisPlayer = this;

                visualCharacter.Initialize();
            }
        }
    }

    public class EnemyCharacter : Character
    {
        public void Initialize()
        {
            // Spawn enemy prefab
            _visualPrefab = GameObject.Instantiate(Resources.Load("Prefabs/Enemy"), Vector3.zero, Quaternion.identity) as GameObject;
            if (_visualPrefab != null)
            {
                _visualPrefab.gameObject.tag = "Enemy";
                _visualPrefab.name = "Enemy" + Tag;

                // Set visual enemy correct attributes
                var visualCharacter = _visualPrefab.GetComponent<VisualEnemy>();
                visualCharacter.AttackStat = AttackStat;
                visualCharacter.DefenseStat = DefenseStat;
                visualCharacter.StartingPosition = StartingPosition;
                visualCharacter.ThisEnemy = this;

                visualCharacter.Initialize();
            }
        }
    }

    // Update attack / defense stats when equipped armor
    public void UpdateAttackStat()
    {
        if (CharacterWeapon.Name == "Staff") AttackStat = 0;
        else if (CharacterWeapon != null) AttackStat += CharacterWeapon.AttackBonus;
    }

    public void UpdateDefensStat()
    {
        if (CharacterArmor != null) DefenseStat += CharacterArmor.DefenseBonus;
    }

    // Return position of the character
    public Vector3 GetPosition()
    {
        if (_visualPrefab != null)
            return _visualPrefab.transform.position;
        else
            return Vector3.zero;
    }
}


