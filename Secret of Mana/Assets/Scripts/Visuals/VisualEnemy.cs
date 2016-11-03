using System;
using UnityEngine;
using System.Collections;

public class VisualEnemy : MonoBehaviour {

    public Vector3 StartingPosition;

    // Display CurrentHealth
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
        transform.SetParent(GameObject.Find("Enemies").transform);
    }

    void OnMouseDown()
    {
        // Only heroes with swords or bows can attack
        if (CharacterManager.SelectedCharacter.CharacterWeapon.Name != "Staff")
        {
            if (!HasDied)
            {
                Debug.Log("Hit " + name);
                HitParticle.Play();

                ThisEnemy.HealthPoints -= (int)(CharacterManager.SelectedCharacter.AttackStat * 0.04f - (DefenseStat * 0.01f));

                if (ThisEnemy.HealthPoints <= 0)
                {
                    // Die ritual
                    Die();
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
        GameManager.CharManager.EnemyList.Remove(ThisEnemy);

        GameManager.CheckAliveEnemies();
    }
}
