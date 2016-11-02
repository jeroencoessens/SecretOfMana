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

    // End game canvasses
    public GameObject LoseCanvas;
    public GameObject WinCanvas;

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

        // Create enemies
        CreateEnemies();

        // Create characters
        CreateCharacters();
        CharManager.Init();

        // Panels
        UIManager = new UIManager();
        UIManager.Init();
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

    void CreateSpecificEnemy(Character.EnemyCharacter enemy, int health, int mana, int tag, Vector3 position)
    {
        enemy.HealthPoints = health;
        enemy.ManaPoints = mana;
        enemy.StartingPosition = position;
        enemy.Tag = tag;
        enemy.CharacterWeapon = new Sword();
        enemy.CharacterArmor = new Armor(Armor.ArmorType.Helmet);
        enemy.UpdateDefensStat();
        enemy.UpdateAttackStat();

        enemy.Initialize();
        CharManager.EnemyList.Add(enemy);
    }

    void CreateEnemies()
    {
        var enemy1 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy1, 50, 0, 1, new Vector3(73, 1.5f, -21));

        var enemy2 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy2, 50, 0, 2, new Vector3(78, 1.5f, -27));

        var enemy3 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy3, 80, 0, 3, new Vector3(65, 1.5f, -27));
        
        var enemy4 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy4, 80, 0, 4, new Vector3(65, 1.5f, -15));
    }

    public void UpdateCharacters()
    {
        bool gameDone = true;

        // check if player 1 is still alive
        if (GameObject.Find("Character1"))
        {
            CharManager.UpdateCharacters(1);
            gameDone = false;
        }

        // check if player 2 is still alive
        else if (GameObject.Find("Character2"))
        {
            CharManager.UpdateCharacters(2);
            gameDone = false;
        }

        // check if player 3 is still alive
        else if (GameObject.Find("Character3"))
        {
            CharManager.UpdateCharacters(3);
            gameDone = false;
        }

        if (gameDone)
        {
            CharacterManager.AllCharactersDied = true;
            EndGame("lost");
        }
    }

    public void CheckAliveEnemies()
    {
        bool gameDone = !(GameObject.Find("Enemies").transform.childCount > 1);

        Debug.Log(GameObject.Find("Enemies").transform.childCount);

        if (gameDone)
            EndGame("won");
    }

    void EndGame(string status)
    {
        if (status == "won")
        {
            WinCanvas.SetActive(true);
            LoseCanvas.SetActive(false);
        }
        else if (status == "lost")
        {
            LoseCanvas.SetActive(true);
            WinCanvas.SetActive(false);
        }

        Time.timeScale = 0.0f;
    }
}
