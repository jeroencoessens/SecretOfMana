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
    private bool HasDied = false;

    // Attributes
    public int AttackStat = 0;
    public int DefenseStat = 0;

    // Reference to Game Manager
    private GameManager GameManager;

    // Particles
    private ParticleSystem HitParticle;
    private ParticleSystem DieParticle;

    void Start()
    {
        HitParticle = transform.Find("HitParticle").GetComponent<ParticleSystem>();
        DieParticle = transform.Find("DieParticle").GetComponent<ParticleSystem>();
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
        if (CharacterManager.SelectedCharacter.CharacterWeapon.Name != "Staff")
        {
            if (!HasDied)
            {
                Debug.Log("Hit " + name);
                HitParticle.Play();

                CurrentHealth -= CharacterManager.SelectedCharacter.AttackStat * 0.035f - (DefenseStat * 0.01f);
                ThisEnemy.HealthPoints = (int)CurrentHealth;

                if (CurrentHealth < 0)
                {
                    // Die ritual
                    Die();

                    GameManager.CheckAliveEnemies();
                }
            }
        }
    }

    void Die()
    {
        HasDied = true;
        GetComponent<MeshRenderer>().enabled = false;
        DieParticle.Play();

        // Destroy enemy
        Destroy(gameObject, 1.5f);
    }
}
