using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    // Lists of entities
    public List<Character.PlayerCharacter> CharacterList = new List<Character.PlayerCharacter>();
    public List<Character.EnemyCharacter> EnemyList = new List<Character.EnemyCharacter>();

    public static Character.PlayerCharacter SelectedCharacter;
    public static bool AllCharactersDied = false;

    // Camera
    public GameObject MainCamera;

    // Use this for initialization
    public void Init () {

        // Player one is focused character
        SelectedCharacter = CharacterList[0];

        // Set camera to focused player
        UpdateCamera();
    }
	
	// Update is called once per frame
	public void Update () {

        // Switch players
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
            if (CharacterList[0] != null && !CharacterList[0].HasDied)
            {
                SelectedCharacter = CharacterList[0];
                UpdateCamera();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterList[1] != null && !CharacterList[1].HasDied)
            {
                SelectedCharacter = CharacterList[1];
                UpdateCamera();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CharacterList[2] != null && !CharacterList[2].HasDied)
            {
                SelectedCharacter = CharacterList[2];
                UpdateCamera();
            }
        }
    }

    void UpdateCamera()
    {
        MainCamera.GetComponent<CameraSwitching>().UpdateCamera();
    }

    public void UpdateCharacters(int player)
    {
        // Select new character to focus ( upon death of another )
        if (CharacterList[player - 1] != null)
            SelectedCharacter = CharacterList[player - 1];
        else
        {
            if(CharacterList[0] != null)
                SelectedCharacter = CharacterList[0];
            else if (CharacterList[1] != null)
                SelectedCharacter = CharacterList[1];
            else if (CharacterList[2] != null)
                SelectedCharacter = CharacterList[2];
        }

        // Set camera to focused player
        UpdateCamera();
    }
}
