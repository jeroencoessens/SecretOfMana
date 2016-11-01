using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanel : ManaPanel
{
    // Current held weapon by focused Character
    public Text WeaponText;

    // Name of Character
    public Text NameText;

    // Current HP & MP of Character
    public Text HPText;
    public Text MPText;

    // Armor and Weapon stats
    public Text AttackText;
    public Text DefenseText;

    public Text ArmorText;

    // Update is called once per frame
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

        WeaponText.text = "Weapon: " + currentCharacter.CharacterWeapon.Name;
        NameText.text = "Name: " + currentCharacter.Name;
        HPText.text = "HP: " + currentCharacter.HealthPoints;
        MPText.text = "MP: " + currentCharacter.ManaPoints;

        AttackText.text = "ATT: " + currentCharacter.AttackStat;
        DefenseText.text = "DEF: " + currentCharacter.DefenseStat;
        ArmorText.text = "Armorpiece: " + currentCharacter.CharacterArmor.ArmorPiece;
    }
}
