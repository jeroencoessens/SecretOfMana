using System;
using UnityEngine;
using System.Collections;

public class VisualEnemy : MonoBehaviour {

    public Vector3 StartingPosition;

    // Display CurrentHealth
    public Character.EnemyCharacter ThisEnemy;
    private bool _hasDied = false;

    // Attack stat
    public int AttackStat = 0;
    public int DefenseStat = 0;

    // Reference to Game Manager
    private GameManager _gameManager;

    // Particles
    private ParticleSystem _hitParticles;
    private ParticleSystem _dieParticles;

    public void Initialize()
    {
        // Reference to Game Manager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _hitParticles = transform.Find("HitParticle").GetComponent<ParticleSystem>();
        _dieParticles = transform.Find("DieParticle").GetComponent<ParticleSystem>();

        transform.position = StartingPosition;
        transform.SetParent(GameObject.Find("Enemies").transform);
    }

    // Damage enemies by clicking ( left mouse )
    void OnMouseDown()
    {
        // Only heroes with swords can directly hit if within distance
        if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Sword" && CharacterManager.SelectedCharacter.CanAttack)
        {
            if (!_hasDied)
            {
                Hit();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Only heroes with bows ( rangers ) can shoot arrows
        if (other.CompareTag("Arrow") && !_hasDied)
        {
            Destroy(other.gameObject);
            Hit();
        }
    }

    void Die()
    {
        Debug.Log(name + " died!");

        _hasDied = true;
        GetComponent<MeshRenderer>().enabled = false;
        _dieParticles.Play();

        // Destroy enemy and remove from list
        Destroy(gameObject, 1.5f);
        GameManager.CharManager.EnemyList.Remove(ThisEnemy);

        // Check if there are still enemies to be killed!
        _gameManager.CheckAliveEnemies();
    }

    void Hit()
    {
        Debug.Log(CharacterManager.SelectedCharacter.Name + " hit " + name + "!");

        _hitParticles.Play();

        ThisEnemy.HealthPoints -= (int)(CharacterManager.SelectedCharacter.AttackStat * 0.04f - (DefenseStat * 0.01f));

        if (ThisEnemy.HealthPoints <= 0)
        {
            // Die ritual
            Die();
        }
    }
}
