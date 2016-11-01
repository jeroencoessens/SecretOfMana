using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Inventory holder
    public static Inventory Inventory;

    //Managers
    private CharacterManager CharManager;
    private UIManager UIManager;

    // Camera
    public GameObject MainCamera;

    // Use this for initialization
    void Start () {
        CreateManagers();
	}
	
	// Update is called once per frame
	void Update () {

        CharManager.Update();
	}

    void CreateManagers()
    {
        // Character and UI managers
        CharManager = new CharacterManager();
        CreateCharacters();
        CharManager.Init();

        UIManager = new UIManager();
    }

    void CreateCharacters()
    {
        // Character 1 = Eddy - Sword
        var eddy = new Character.PlayerCharacter();
        CreateSpecificCharacter(eddy, 120, 2, "Eddy", 1, new Sword(), new Armor(Armor.ArmorType.Chestplate), "Warrior", Color.blue, new Vector3(5, 1.5f, 0));

        // Character 2 = Barry - Bow
        var barry = new Character.PlayerCharacter();
        CreateSpecificCharacter(barry, 70, 6, "Barry", 2, new Bow(), new Armor(Armor.ArmorType.Pants), "Ranger", Color.yellow, new Vector3(0, 1.5f, 0));

        // Character 1 = Gandalf - Staff
        var gandalf = new Character.PlayerCharacter();
        CreateSpecificCharacter(gandalf, 100, 12, "Gandalf", 3, new Staff(), new Armor(Armor.ArmorType.Boots), "Wizard", Color.magenta, new Vector3(-5, 1.5f, 0));

        CharacterManager.SelectedCharacter = CharManager.CharacterList[0];

        foreach (var character in CharManager.CharacterList)
        {
            Debug.Log("Characterlist contains " + character.Name +" , he is a " + character.Role + "!");
        }

        MainCamera.GetComponent<CameraSwitching>().Initialize();

        CharManager.MainCamera = MainCamera;
    }

    void CreateSpecificCharacter(Character.PlayerCharacter player, int health, int mana, string name, int UITag, Weapon weapon, Armor armor, string role, Color color, Vector3 position)
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
        player.Color = color;
        player.StartingPosition = position;

        player.Initialize();
        CharManager.CharacterList.Add(player);
    }
}
