using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text SelectedCharacter;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    SelectedCharacter.text = CharacterManager.SelectedCharacter.Tag.ToString();
	}
}
