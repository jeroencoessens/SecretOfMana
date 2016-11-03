using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : ManaPanel
{
    // Name of Character
    public Text NameText;

    // Current HP & MP of Character
    public Text HPText;
    public Text MPText;

    // Armor and Weapon stats
    public Text AttackText;
    public Text DefenseText;

    // More info
    public Text RoleText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShouldOpen = !ShouldOpen;

            // Normal refresh
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

    // overload for character
    void RefreshPanel(Character.PlayerCharacter currentCharacter)
    {
        // update text:
        // Weapon, Name, HP, PP ( anything you want )
        // cached Texts:

        NameText.text = "Name: " + currentCharacter.Name;
        HPText.text = "HP: " + currentCharacter.HealthPoints;
        MPText.text = "MP: " + currentCharacter.ManaPoints;

        AttackText.text = "ATT: " + currentCharacter.AttackStat;
        DefenseText.text = "DEF: " + currentCharacter.DefenseStat;

        RoleText.text = "He is a " + currentCharacter.Role;
    }
}
