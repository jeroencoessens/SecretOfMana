using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    public List<Character.PlayerCharacter> CharacterList = new List<Character.PlayerCharacter>();
    public List<Character.EnemyCharacter> EnemyList = new List<Character.EnemyCharacter>();

    public static Character.PlayerCharacter SelectedCharacter;
    public static bool AllCharactersDied = false;

    // Camera
    public GameObject MainCamera;

    // Use this for initialization
    public void Init () {
        SelectedCharacter = CharacterList[0];
        UpdateCamera();
    }
	
	// Update is called once per frame
	public void Update () {

	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        if (CharacterList[0] != null)
	        {
	            if (!CharacterList[0].HasDied)
	            {
	                SelectedCharacter = CharacterList[0];
	                UpdateCamera();
	            }
	        }
	    }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CharacterList[1] != null)
            {
                if (!CharacterList[1].HasDied)
                {
                    SelectedCharacter = CharacterList[1];
                    UpdateCamera();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CharacterList[2] != null)
            {
                if (!CharacterList[2].HasDied)
                {
                    SelectedCharacter = CharacterList[2];
                    UpdateCamera();
                }
            }
        }
    }

    void UpdateCamera()
    {
        MainCamera.GetComponent<CameraSwitching>().UpdateCamera();
    }

    public void UpdateCharacters(int player)
    {
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
        UpdateCamera();
    }
}
