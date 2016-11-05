using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : ManaPanel
{
    // Name of Character + Weapon
    public Text NameText;
    public Text WeaponText;

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

            // Normal refresh ( open/close )
            RefreshPanel();

            //Refresh with correct Character
            RefreshPanel(CharacterManager.SelectedCharacter);
        }

        // When panel open, update values
        if (ShouldOpen)
            RefreshPanel(CharacterManager.SelectedCharacter);
    }

    // update for selected character ( overload for the sake of overloading, no real difference )
    void RefreshPanel(Character.PlayerCharacter currentCharacter)
    {
        // Update text

        NameText.text = "Name: " + currentCharacter.Name;
        WeaponText.text = "Weapon: " + currentCharacter.CharacterWeapon.Name;

        HPText.text = "HP: " + currentCharacter.HealthPoints;
        MPText.text = "MP: " + currentCharacter.ManaPoints;

        AttackText.text = "ATT: " + currentCharacter.AttackStat;
        DefenseText.text = "DEF: " + currentCharacter.DefenseStat;

        RoleText.text = "He is a " + currentCharacter.Role;
    }
}
