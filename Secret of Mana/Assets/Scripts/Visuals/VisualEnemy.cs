using System;
using UnityEngine;
using System.Collections;

public class VisualEnemy : MonoBehaviour {

    public Vector3 StartingPosition;

    // Display CurrentHealth
    public Character.EnemyCharacter ThisEnemy;
    private bool HasDied = false;

    // Attack stat
    public int AttackStat = 0;
    public int DefenseStat = 0;

    // Reference to Game Manager
    private GameManager GameManager;

    // Particles
    private ParticleSystem HitParticle;
    private ParticleSystem DieParticle;

    public void Initialize()
    {
        // Reference to Game Manager
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        HitParticle = transform.Find("HitParticle").GetComponent<ParticleSystem>();
        DieParticle = transform.Find("DieParticle").GetComponent<ParticleSystem>();

        transform.position = StartingPosition;
        transform.SetParent(GameObject.Find("Enemies").transform);
    }

    // Damage enemies by clicking ( left mouse )
    void OnMouseDown()
    {
        // Only heroes with swords can directly hit if within distance
        if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Sword" && CharacterManager.SelectedCharacter.CanAttack)
        {
            if (!HasDied)
            {
                Hit();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Only heroes with bows ( rangers ) can shoot arrows
        if (other.CompareTag("Arrow") && !HasDied)
        {
            Destroy(other.gameObject);
            Hit();
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

        // Check if there are still enemies to be killed!
        GameManager.CheckAliveEnemies();
    }

    void Hit()
    {
        Debug.Log(CharacterManager.SelectedCharacter.Name + " hit " + name + "!");

        HitParticle.Play();

        ThisEnemy.HealthPoints -= (int)(CharacterManager.SelectedCharacter.AttackStat * 0.04f - (DefenseStat * 0.01f));

        if (ThisEnemy.HealthPoints <= 0)
        {
            // Die ritual
            Die();
        }
    }
}
