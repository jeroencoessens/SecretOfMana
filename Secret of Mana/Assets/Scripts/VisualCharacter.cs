using UnityEngine;
using System.Collections;

public class VisualCharacter : MonoBehaviour
{
    public Color ColorForMaterial;
    public Material _material;
    public Vector3 StartingPosition;

    // Initialized
    private bool IsInitialized = false;

    // Camera and selection of characters
    public bool SelectedCharacter = false;
    public int ThisTag = 0;

	// Use this for initialization
	void Start ()
	{

	}

    public void Initialize()
    {
        GetComponent<Renderer>().material.color = ColorForMaterial;
        transform.position = StartingPosition;

        IsInitialized = true;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!IsInitialized)
	        return;

	    if (CharacterManager.SelectedCharacter.Tag == ThisTag)
	        SelectedCharacter = true;
	    else
	        SelectedCharacter = false;

        // Movement when selected
	    if (SelectedCharacter)
	    {
            float speed = 5.0f;

            // Movement
            if (Input.GetAxisRaw("Horizontal") > 0)
                transform.Translate(Time.deltaTime * speed, 0, 0);

            if (Input.GetAxisRaw("Horizontal") < 0)
                transform.Translate(-Time.deltaTime * speed, 0, 0);

            if (Input.GetAxisRaw("Vertical") > 0)
                transform.Translate(0, 0, Time.deltaTime * speed);

            if (Input.GetAxisRaw("Vertical") < 0)
                transform.Translate(0, 0, -Time.deltaTime * speed);
        }
    }
}
