using System;
using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{
    // Attributes for prefabs
    public Color ColorForMaterial;
    public Vector3 StartingPosition;

    // Initialized
    private bool IsInitialized = false;

    // Camera and selection of characters
    public bool SelectedCharacter = false;
    public int ThisTag = 0;

    // Attributes for End Game
    public Character.PlayerCharacter ThisPlayer;

    // Reference to Game Manager
    private GameManager GameManager;

    // Damage
    private float timerOnDamage = 0.0f;

    // Particles ( onyl for healer )
    private ParticleSystem HealParticles;
    
    public void Initialize()
    {
        // Reference to Game Manager
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<Renderer>().material.color = ColorForMaterial;
        transform.position = StartingPosition;
        transform.parent = GameObject.Find("Characters").transform;
        HealParticles = transform.Find("HealParticles").GetComponent<ParticleSystem>();

        IsInitialized = true;
    }
	
	void Update ()
	{
	    if (!IsInitialized)
	        return;

	    SelectedCharacter = CharacterManager.SelectedCharacter.Tag == ThisTag;

        // Movement when selected
	    if (SelectedCharacter)
	    {
            float speed = 5.0f;

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

        // Healing ( max 300 HP )
	    if (CharacterManager.SelectedCharacter.CharacterWeapon.Name == "Staff")
	    {
	        if (Input.GetMouseButtonDown(0))
	        {
	            foreach (var character in GameManager.CharManager.CharacterList)
	            {
                    if(character.HealthPoints < 300)
	                    character.HealthPoints += 3;
                    else
                        character.HealthPoints = 300;
                }

	            HealParticles.Play();
            }
        }
    }

    // Trigger for damage
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            timerOnDamage += Time.deltaTime;

            if (timerOnDamage > 0.5f)
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
                timerOnDamage = 0.0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            timerOnDamage = 0.0f;
        }
    }

    void Die()
    {
        // Set Camera back to parentless ( if was main player )
        if (SelectedCharacter)
        {
            if (transform.Find("Main Camera") != null)
                transform.Find("Main Camera").parent = null;
            if (transform.Find("CameraTracer") != null)
                transform.Find("CameraTracer").parent = null;
        }

        // Destroy this character
        Destroy(gameObject);
        ThisPlayer.HasDied = true;

        // Delete character items from inventory
        Inventory.ItemList.Remove(ThisPlayer.CharacterWeapon);
        Inventory.ItemList.Remove(ThisPlayer.CharacterArmor);

        // Update characters
        if(SelectedCharacter)
            GameManager.UpdateCharacters(ThisTag);
    }
}
