using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Inventory holder
    public static Inventory Inventory;

    //Managers
    private CharacterManager CharManager;
    private UIManager UIManager;

    // Use this for initialization
    void Start () {
        CreateManagers();
	
        // Create 3 characters and couple of enemies
	}
	
	// Update is called once per frame
	void Update () {

        CharManager.Update();
	}

    void CreateManagers()
    {
        // Character and UI managers
        CharManager = new CharacterManager();
        CharManager.Init();
        CreateCharacters();

        UIManager = new UIManager();
    }

    void CreateCharacters()
    {
        // Character 1 = Eddy - Sword
        var eddy = new Character.PlayerCharacter();
        CreateSpecificCharacter(eddy, 120, 2, "Eddy", 1, new Sword(), new Armor(Armor.ArmorType.Chestplate), "Warrior");

        // Character 2 = Barry - Bow
        var barry = new Character.PlayerCharacter();
        CreateSpecificCharacter(barry, 70, 6, "Barry", 2, new Bow(), new Armor(Armor.ArmorType.Pants), "Ranger");

        // Character 1 = Gandalf - Staff
        var gandalf = new Character.PlayerCharacter();
        CreateSpecificCharacter(gandalf, 100, 12, "Gandalf", 3, new Staff(), new Armor(Armor.ArmorType.Boots), "Wizard");

        CharacterManager.SelectedCharacter = CharManager.CharacterList[0];

        foreach (var character in CharManager.CharacterList)
        {
            Debug.Log("Characterlist contains " + character.Name +" , he is a " + character.Role + "!");
        }
    }

    void CreateSpecificCharacter(Character.PlayerCharacter player, int health, int mana, string name, int UITag, Weapon weapon, Armor armor, string role)
    {
        player.Name = name;
        player.HealthPoints = health;
        player.ManaPoints = mana;
        player.CharacterWeapon = weapon;
        player.CharacterArmor = armor;
        player.Tag = UITag;
        player.UpdateDefensStat();
        player.UpdateAttackStat();
        player.Role = role;
        CharManager.CharacterList.Add(player);
    }
}
