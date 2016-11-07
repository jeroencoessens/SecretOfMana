using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text SelectedCharacter;
    public Text ArrowsText;

    // Current amount of arrows in scene
    private Transform _arrowsCirculating;

    void Start()
    {
        _arrowsCirculating = GameObject.Find("Arrows").transform;
    }

	void Update ()
	{
        // Update HUD
	    SelectedCharacter.text = CharacterManager.SelectedCharacter.Tag.ToString();
	    ArrowsText.text = _arrowsCirculating.childCount.ToString();
	}
}
