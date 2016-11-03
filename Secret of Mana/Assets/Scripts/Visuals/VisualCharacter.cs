using System;
using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{
    public Color ColorForMaterial;
    public Material _material;
    public Vector3 StartingPosition;

    // Initialized
    private bool IsInitialized = false;

    // Camera and selection of characters
    public bool SelectedCharacter = false;
    public int ThisTag = 0;

    // Attributes for End Game
    public float CurrentHealth = 0.0f;
    public int AttackStat = 0;
    public int DefenseStat = 0;
    public Character.PlayerCharacter ThisPlayer;

    // Reference to Game Manager
    private GameManager GameManager;

    // Damage
    private float timerOnDamage = 0.0f;

    // Particles ( onyl for healer )
    private ParticleSystem HealParticles;
    
    public void Initialize()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        HealParticles = transform.Find("HealParticles").GetComponent<ParticleSystem>();

        GetComponent<Renderer>().material.color = ColorForMaterial;
        transform.position = StartingPosition;
        transform.parent = GameObject.Find("Characters").transform;

        IsInitialized = true;
    }
	
	void Update ()
	{
	    if (!IsInitialized)
	        return;

	    if (CharacterManager.SelectedCharacter.Tag == ThisTag)
	        SelectedCharacter = true;
	    else
	        SelectedCharacter = false;

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

        // Healing
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

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            timerOnDamage += Time.deltaTime;

            if (timerOnDamage > 0.5f)
            {
                Debug.Log("Hit " + name);

                CurrentHealth -= (other.GetComponent<VisualEnemy>().AttackStat * 0.03f - (DefenseStat * 0.01f));
                ThisPlayer.HealthPoints = (int) CurrentHealth;

                if (CurrentHealth < 0)
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
        // Set Camera back to zero parents ( if was main player )
        if (transform.Find("Main Camera") != null)
            transform.Find("Main Camera").parent = null;

        // Destroy this character
        Destroy(gameObject);
        ThisPlayer.HasDied = true;
        GameManager.CharManager.CharacterList.Remove(ThisPlayer);

        // Update characters
        GameManager.UpdateCharacters(ThisTag);
    }
}
