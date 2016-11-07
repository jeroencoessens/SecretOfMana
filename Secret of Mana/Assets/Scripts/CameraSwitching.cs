using UnityEngine;
using System.Collections;

public class CameraSwitching : MonoBehaviour
{
    // The three characters
    private GameObject _characterOne;
    private GameObject _characterTwo;
    private GameObject _characterThree;

    // Timer info ( for smooth cycle )
    private bool _shouldUpdate;
    private float _timerUpdater;
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
        if (_shouldUpdate)
        {
            // Start cycle
            _timerUpdater += Time.deltaTime * CycleSpeed;

            float offset = 8.0f;
            
            // Set the selected character as focus ( added art beneath selected character )
            if (_characterOne != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterOne.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterOne.transform.position.x, transform.position.y, _characterOne.transform.position.z - offset), _timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterOne.transform.position.x, CameraTracer.position.y, _characterOne.transform.position.z), _timerUpdater);

                transform.SetParent(_characterOne.transform);
                CameraTracer.SetParent(_characterOne.transform);
            }
            else if (_characterTwo != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterTwo.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterTwo.transform.position.x, transform.position.y, _characterTwo.transform.position.z - offset), _timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterTwo.transform.position.x, CameraTracer.position.y, _characterTwo.transform.position.z), _timerUpdater);

                transform.SetParent(_characterTwo.transform);
                CameraTracer.SetParent(_characterTwo.transform);
            }
            else if (_characterThree != null && CharacterManager.SelectedCharacter.Tag.ToString() == _characterThree.tag)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(_characterThree.transform.position.x, transform.position.y, _characterThree.transform.position.z - offset), _timerUpdater);
                CameraTracer.position = Vector3.Lerp(CameraTracer.position, new Vector3(_characterThree.transform.position.x, CameraTracer.position.y, _characterThree.transform.position.z), _timerUpdater);

                transform.SetParent(_characterThree.transform);
                CameraTracer.SetParent(_characterThree.transform);
            }

            // After cycle ended, stop calculating
            if (_timerUpdater > 1.0f)
                _shouldUpdate = false;
        }
    }

    // Update the camera position to correct ( selected ) character
    public void UpdateCamera()
    {
        _timerUpdater = 0.0f;
        _shouldUpdate = true;
    }
}
