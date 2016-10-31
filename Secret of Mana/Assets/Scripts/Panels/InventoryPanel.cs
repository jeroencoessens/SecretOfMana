using UnityEngine;
using System.Collections;

public class InventoryPanel : ManaPanel {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.I))
        {
            OpenPanel();
        }
    }

    void OpenPanel()
    {

    }
}
