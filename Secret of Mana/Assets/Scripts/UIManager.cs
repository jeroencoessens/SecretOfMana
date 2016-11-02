using UnityEngine;
using System.Collections;

public class UIManager
{
    private GameObject MainPanel;

    private GameObject InvPanel;
    private GameObject CharPanel;

	// Use this for initialization
	public void Init ()
	{
        MainPanel = GameObject.Instantiate(Resources.Load("Prefabs/Panels/Panels")) as GameObject;

	    InvPanel = MainPanel.transform.Find("InventoryPanel").gameObject;
        CharPanel = MainPanel.transform.Find("CharacterPanel").gameObject;
    }
}
