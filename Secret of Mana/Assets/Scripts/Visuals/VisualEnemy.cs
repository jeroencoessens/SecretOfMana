using System;
using UnityEngine;
using System.Collections;

public class VisualEnemy : MonoBehaviour {

    public Vector3 StartingPosition;

    // Initialized
    private bool IsInitialized = false;

    // Display Health
    public float CurrentHealth = 0;
    public Character.EnemyCharacter ThisEnemy;

    // Attributes
    public int AttackStat = 0;
    public int DefenseStat = 0;

    // Reference to Game Manager
    private GameManager GameManager;

    void Start()
    {
        
    }

    public void Initialize()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.position = StartingPosition;
        transform.parent = GameObject.Find("Enemies").transform;

        IsInitialized = true;
    }


    // Update is called once per frame
    void Update () {
        if (!IsInitialized)
            return;
    }

    void OnMouseDown()
    {
        Debug.Log("Hit " + this.name);
        CurrentHealth -= CharacterManager.SelectedCharacter.AttackStat * 0.035f - (DefenseStat * 0.01f);
        ThisEnemy.HealthPoints = (int) CurrentHealth;

        if (CurrentHealth < 0)
        {
            Destroy(gameObject);
            GameManager.CheckAliveEnemies();
        }
    }
}
