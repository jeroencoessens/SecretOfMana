using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    public List<Character.PlayerCharacter> CharacterList = new List<Character.PlayerCharacter>();
    public List<Character.EnemyCharacter> EnemyList = new List<Character.EnemyCharacter>();

    public static Character.PlayerCharacter SelectedCharacter;

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
	        SelectedCharacter = CharacterList[0];
	        UpdateCamera();
	    }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedCharacter = CharacterList[1];
            UpdateCamera();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedCharacter = CharacterList[2];
            UpdateCamera();
        }
    }

    void UpdateCamera()
    {
        MainCamera.GetComponent<CameraSwitching>().UpdateCamera();
    }
}
