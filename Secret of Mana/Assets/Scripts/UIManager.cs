using UnityEngine;
using System.Collections;

public class UIManager
{
    // The main canvas which holds the inventory and character panels
    private GameObject MainPanel;

	// Use this for initialization
	public void Init ()
	{
        // Spawn canvas
        MainPanel = GameObject.Instantiate(Resources.Load("Prefabs/Panels/Panels")) as GameObject;
    }
}
