using UnityEngine;
using System.Collections;

public class InventoryPanel : ManaPanel {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShouldOpen = !ShouldOpen;

            // Inventory for all characters
            RefreshPanel();
        }
    }
}
