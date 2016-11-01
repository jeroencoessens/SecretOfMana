using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour
{
    private GameObject CharacterOne;
    private GameObject CharacterTwo;
    private GameObject CharacterThree;

	// Use this for initialization
	void Start () {
	
	}

    public void Initialize()
    {
        CharacterOne = GameObject.Find("Character1");
        CharacterTwo = GameObject.Find("Character2");
        CharacterThree = GameObject.Find("Character3");
    }

    // Update is called once per frame
    void Update ()
    {

    }

    public void UpdateCamera()
    {
        float offset = 8.0f;

        if (CharacterManager.SelectedCharacter.Tag.ToString() == CharacterOne.tag)
        {
            transform.position = new Vector3(CharacterOne.transform.position.x, transform.position.y, CharacterOne.transform.position.z - offset);
            transform.parent = CharacterOne.transform;
        }
        else if (CharacterManager.SelectedCharacter.Tag.ToString() == CharacterTwo.tag)
        {
            transform.position = new Vector3(CharacterTwo.transform.position.x, transform.position.y, CharacterTwo.transform.position.z - offset);
            transform.parent = CharacterTwo.transform;
        }
        else if (CharacterManager.SelectedCharacter.Tag.ToString() == CharacterThree.tag)
        {
            transform.position = new Vector3(CharacterThree.transform.position.x, transform.position.y, CharacterThree.transform.position.z - offset);
            transform.parent = CharacterThree.transform;
        }
    }
}
