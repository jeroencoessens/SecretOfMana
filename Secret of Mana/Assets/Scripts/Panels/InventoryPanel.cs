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
    }

    void RefreshPanel(Character.PlayerCharacter currentCharacter)
    {
        WeaponText.text = "Weapons: ";
        ArmorText.text = "Armor pieces: ";

        // Add all items from the inventory list
        foreach (var item in Inventory.ItemList)
        {
            if (item.ItemTypeMember == Item.ItemType.Weapon)
            {
                WeaponText.text += item.Name;
                WeaponText.text += ", ";
            }

            if (item.ItemTypeMember == Item.ItemType.Armor)
            {
                ArmorText.text += item.Name;
                ArmorText.text += ", ";
            }
        }

        // Edit the text
        string value = WeaponText.text;
        value = value.Substring(0, value.Length - 2);
        WeaponText.text = value;

        value = ArmorText.text;
        value = value.Substring(0, value.Length - 2);
        ArmorText.text = value;
    }
}
