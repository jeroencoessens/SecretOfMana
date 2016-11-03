using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text SelectedCharacter;
	
	void Update ()
	{
	    SelectedCharacter.text = CharacterManager.SelectedCharacter.Tag.ToString();
	}
}
