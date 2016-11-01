using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Inventory holder
    public static Inventory Inventory;

    //Managers
    private CharacterManager CharManager;
    private UIManager UIManager;

    // Use this for initialization
    void Start () {
        CreateManagers();
	
        // Create 3 characters and couple of enemies
	}
	
	// Update is called once per frame
	void Update () {

        CharManager.Update();
	
	}

    void CreateManagers()
    {
        // Character and UI managers
        CharManager = new CharacterManager();
        CharManager.Init();

        UIManager = new UIManager();
    }
}
