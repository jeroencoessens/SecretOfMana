using System;
using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{
    // Attributes for prefabs
    public Color ColorForMaterial;
    public Vector3 StartingPosition;

    // Initialized
    private bool _isInitialized = false;

    // Camera and selection of characters
    public bool SelectedCharacter = false;
    public int ThisTag = 0;

    // Attributes for End Game
    public Character.PlayerCharacter ThisPlayer;
    private bool _hasDied = false;

    // Reference to Game Manager
    private GameManager _gameManager;

    // Damage
    private float _timerOnDamage = 0.0f;

    // Particles
    private ParticleSystem _healParticles;
    private ParticleSystem _dieParticles;
    
    public void Initialize()
    {
        // Reference to Game Manager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<Renderer>().material.color = ColorForMaterial;
        transform.position = StartingPosition;
        transform.parent = GameObject.Find("Characters").transform;

        _healParticles = transform.Find("HealParticles").GetComponent<ParticleSystem>();
        _dieParticles = transform.Find("DieParticles").GetComponent<ParticleSystem>();

        _isInitialized = true;
    }
	
	void Update ()
	{
	    if (!_isInitialized)
	        return;

	    if (!_hasDied)
	    {
            SelectedCharacter = CharacterManager.SelectedCharacter.Tag == ThisTag;

            // Movement when selected
            if (SelectedCharacter)
            {
                var speed = 5.0f;

                // Movement ( arrows & WASD )
                if (Input.GetAxisRaw("Horizontal") > 0)
                    transform.Translate(Time.deltaTime * speed, 0, 0);

                if (Input.GetAxisRaw("Horizontal") < 0)
                    transform.Translate(-Time.deltaTime * speed, 0, 0);

                if (Input.GetAxisRaw("Vertical") > 0)
                    transform.Translate(0, 0, Time.deltaTime * speed);

                if (Input.GetAxisRaw("Vertical") < 0)
                    transform.Translate(0, 0, -Time.deltaTime * speed);
            }

            // Weapon behaviour
            if (Input.GetMouseButtonDown(0))
            {
                if (ThisPlayer == CharacterManager.SelectedCharacter)
                {
                    if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Bow")
                        ThisPlayer.CharacterWeapon.Behaviour(this);

                    else if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Sword")
                        ThisPlayer.CharacterWeapon.Behaviour();
                }

                if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Staff")
                {
                    ThisPlayer.CharacterWeapon.Behaviour();
                    _healParticles.Play();
                }
            }
        }
    }

    // Trigger for damage
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && !_hasDied)
        {
            CharacterManager.SelectedCharacter.CanAttack = true;

            _timerOnDamage += Time.deltaTime;

            if (_timerOnDamage > 0.5f)
            {
                Debug.Log(name + " got hit by " + other.name + "!");

                // Apply damage
                ThisPlayer.HealthPoints -= (int) (other.GetComponent<VisualEnemy>().AttackStat * 0.03f - (ThisPlayer.DefenseStat * 0.01f));

                if (ThisPlayer.HealthPoints <= 0)
                {
                    // Die ritual
                    Die();
                }

                // reset timer for next attack
                _timerOnDamage = 0.0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _timerOnDamage = 0.0f;
            CharacterManager.SelectedCharacter.CanAttack = false;
        }
    }

    void Die()
    {
        Debug.Log(ThisPlayer.Name + "died!");

        // Set Camera back to parentless ( if was main player )
        if (SelectedCharacter)
        {
            if (transform.Find("Main Camera") != null)
                transform.Find("Main Camera").parent = null;
            if (transform.Find("CameraTracer") != null)
                transform.Find("CameraTracer").parent = null;
        }

        _hasDied = true;
        GetComponent<MeshRenderer>().enabled = false;
        name = "Died";
        _dieParticles.Play();

        // Destroy enemy
        Destroy(gameObject, 1.5f);
        ThisPlayer.HasDied = true;

        // Delete character items from inventory
        Inventory.ItemList.Remove(ThisPlayer.CharacterWeapon);
        Inventory.ItemList.Remove(ThisPlayer.CharacterArmor);

        // Update characters
        if(SelectedCharacter)
            _gameManager.UpdateCharacters(ThisTag);
    }
}
