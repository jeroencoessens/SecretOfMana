using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour
{
    private GameObject _characterOne;
    private GameObject _characterTwo;
    private GameObject _characterThree;

    private bool shouldUpdate = false;
    private float timerUpdater = 0.0f;

    public Transform CameraTracer;

	// Use this for initialization
	void Start () {
	    
	}

    public void Initialize()
    {
        _characterOne = GameObject.Find("Character1");
        _characterTwo = GameObject.Find("Character2");
        _characterThree = GameObject.Find("Character3");
    }

    // Update is called once per frame
    void Update ()
    {
        if (shouldUpdate)
        {
            timerUpdater += Time.deltaTime * 1.4f;

            float offset = 8.0f;

            if (_characterOne != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterOne.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterOne.transform.position.x, transform.position.y, _characterOne.transform.position.z - offset), timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterOne.transform.position.x, CameraTracer.position.y, _characterOne.transform.position.z), timerUpdater);
                transform.SetParent(_characterOne.transform);
                CameraTracer.SetParent(_characterOne.transform);
            }
            else if (_characterTwo != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterTwo.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterTwo.transform.position.x, transform.position.y, _characterTwo.transform.position.z - offset), timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterTwo.transform.position.x, CameraTracer.position.y, _characterTwo.transform.position.z), timerUpdater);
                transform.SetParent(_characterTwo.transform);
                CameraTracer.SetParent(_characterTwo.transform);
            }
            else if (_characterThree != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterThree.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterThree.transform.position.x, transform.position.y, _characterThree.transform.position.z - offset), timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterThree.transform.position.x, CameraTracer.position.y, _characterThree.transform.position.z), timerUpdater);
                transform.SetParent(_characterThree.transform);
                CameraTracer.SetParent(_characterThree.transform);
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
