using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour
{
    // The three characters
    private GameObject _characterOne;
    private GameObject _characterTwo;
    private GameObject _characterThree;

    // Timer info ( for smooth cycle )
    private bool shouldUpdate = false;
    private float timerUpdater = 0.0f;
    public float CycleSpeed = 1.4f;

    // Visual addition to cycle
    public Transform CameraTracer;

    public void Initialize()
    {
        _characterOne = GameObject.Find("Character1");
        _characterTwo = GameObject.Find("Character2");
        _characterThree = GameObject.Find("Character3");
    }

    // Update is called once per frame
    void Update ()
    {
        // Check if should cycle
        if (shouldUpdate)
        {
            // Start cycle
            timerUpdater += Time.deltaTime * CycleSpeed;

            float offset = 8.0f;

            // Set the selected character as focus
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

            // After cycle ended, stop calculating
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
