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
    public float Health = 0.0f;
    public int AttackStat = 0;
    public int DefenseStat = 0;
    public Character.PlayerCharacter ThisPlayer;

    // Reference to Game Manager
    private GameManager GameManager;

    // Damage
    private float timerOnDamage = 0.0f;
    
    public void Initialize()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GetComponent<Renderer>().material.color = ColorForMaterial;
        transform.position = StartingPosition;

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
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            timerOnDamage += Time.deltaTime;

            if (timerOnDamage > 0.5f)
            {
                Debug.Log("Hit Character " + tag);

                Health -= other.GetComponent<VisualEnemy>().AttackStat*0.035f - (DefenseStat*0.01f);
                ThisPlayer.HealthPoints = (int) Health;

                if (Health < 0)
                {
                    // Set Camera back to zero parents ( if was main player )
                    if(transform.Find("Main Camera") != null)
                        transform.Find("Main Camera").parent = null;

                    // Destroy this character
                    Destroy(gameObject);
                    ThisPlayer.HasDied = true;
                    
                    // Update characters
                    if(CharacterManager.SelectedCharacter == ThisPlayer)
                    GameManager.UpdateCharacters();
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
}
