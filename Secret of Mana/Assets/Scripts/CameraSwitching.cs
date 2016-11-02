using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour
{
    private GameObject CharacterOne;
    private GameObject CharacterTwo;
    private GameObject CharacterThree;

    private bool shouldUpdate = false;
    private float timerUpdater = 0.0f;

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
        if (shouldUpdate)
        {
            timerUpdater += Time.deltaTime * 1.5f;

            float offset = 8.0f;

            if (CharacterOne != null && CharacterManager.SelectedCharacter.Tag.ToString() == CharacterOne.tag)
            {
                //transform.position = new Vector3(CharacterOne.transform.position.x, transform.position.y, CharacterOne.transform.position.z - offset);
                transform.position = Vector3.Lerp(transform.position, new Vector3(CharacterOne.transform.position.x, transform.position.y, CharacterOne.transform.position.z - offset), timerUpdater);
                transform.parent = CharacterOne.transform;
            }
            else if (CharacterTwo != null && CharacterManager.SelectedCharacter.Tag.ToString() == CharacterTwo.tag)
            {
                //transform.position = new Vector3(CharacterTwo.transform.position.x, transform.position.y, CharacterTwo.transform.position.z - offset);
                transform.position = Vector3.Lerp(transform.position, new Vector3(CharacterTwo.transform.position.x, transform.position.y, CharacterTwo.transform.position.z - offset), timerUpdater);
                transform.parent = CharacterTwo.transform;
            }
            else if (CharacterThree != null && CharacterManager.SelectedCharacter.Tag.ToString() == CharacterThree.tag)
            {
                //transform.position = new Vector3(CharacterThree.transform.position.x, transform.position.y, CharacterThree.transform.position.z - offset);
                transform.position = Vector3.Lerp(transform.position, new Vector3(CharacterThree.transform.position.x, transform.position.y, CharacterThree.transform.position.z - offset), timerUpdater);
                transform.parent = CharacterThree.transform;
            }

            if (timerUpdater > 1.0f)
            {
                shouldUpdate = false;
            }
        }
    }

    public void UpdateCamera()
    {
        timerUpdater = 0.0f;
        shouldUpdate = true;
    }
}
