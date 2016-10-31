using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    public List<Character.PlayerCharacter> CharacterList = new List<Character.PlayerCharacter>();
    public List<Character.EnemyCharacter> EnemyList = new List<Character.EnemyCharacter>();

    public Character.PlayerCharacter SelectedCharacter;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        SelectedCharacter = CharacterList[0];
	    }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedCharacter = CharacterList[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedCharacter = CharacterList[2];
        }
    }
}
