using UnityEngine;
using System.Collections;

public class UIManager
{
    // The main canvas which holds the inventory and character panels
    private GameObject MainPanel;

	// Use this for initialization
	public void Init ()
	{
        // Spawn canvas ( with panels )
        MainPanel = GameObject.Instantiate(Resources.Load("Prefabs/Panels")) as GameObject;
    }
}
