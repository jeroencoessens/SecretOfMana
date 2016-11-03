using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryPanel : ManaPanel {

    // Current held weapon by focused Character
    public Text WeaponText;
    public Text ArmorText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShouldOpen = !ShouldOpen;

            // Inventory for all characters
            RefreshPanel();

            //Refresh with correct Character
            RefreshPanel(CharacterManager.SelectedCharacter);
        }

        // When panel open, update values
        if (ShouldOpen)
        {
            RefreshPanel(CharacterManager.SelectedCharacter);
        }
    }

    void RefreshPanel(Character.PlayerCharacter currentCharacter)
    {
        WeaponText.text = "Weapon: " + currentCharacter.CharacterWeapon.Name;
        ArmorText.text = "Armorpiece: " + currentCharacter.CharacterArmor.ArmorPiece;
    }
}
