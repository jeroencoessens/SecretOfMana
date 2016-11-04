using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text SelectedCharacter;
    public Text ArrowsText;

    private Transform _arrowsCirculating;

    void Start()
    {
        _arrowsCirculating = GameObject.Find("Arrows").transform;
    }

	void Update ()
	{
	    SelectedCharacter.text = CharacterManager.SelectedCharacter.Tag.ToString();
	    ArrowsText.text = _arrowsCirculating.childCount.ToString();

	}
}
