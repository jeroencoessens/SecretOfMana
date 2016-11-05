using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Inventory holder
    public static Inventory Inventory;

    //Managers
    public static CharacterManager CharManager;
    public static UIManager UIManager;

    // Camera
    public GameObject MainCamera;

    // End game canvasses
    public GameObject LoseCanvas;
    public GameObject WinCanvas;

    void Start () {

        CreateManagers();
    }
	
	void Update () {

        // Update that character manager ( input )
        CharManager.Update();

        // Reset
	    if (Input.GetKeyDown(KeyCode.R))
	    {
	        Time.timeScale = 1.0f;
	        SceneManager.LoadScene(0);
	    }
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

        // Debug
        foreach (var character in CharManager.CharacterList)
        {
            Debug.Log("Characterlist contains " + character.Name +" , he is a " + character.Role + "!");
        }

        // Camera
        MainCamera.GetComponent<CameraSwitching>().Initialize();
        CharManager.MainCamera = MainCamera;
    }

    void CreateEnemies()
    {
        // Create some enemies ( position is kind of off due to NavMesh )
        var enemy1 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy1, 50, 0, 1, new Vector3(37, 1.5f, -22));

        var enemy2 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy2, 50, 0, 2, new Vector3(40, 1.5f, -28));

        var enemy3 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy3, 80, 0, 3, new Vector3(55, 1.5f, -30));

        var enemy4 = new Character.EnemyCharacter();
        CreateSpecificEnemy(enemy4, 80, 0, 4, new Vector3(70, 1.5f, -25));
    }

    void CreateSpecificCharacter(Character.PlayerCharacter player, int health, int mana, string name, int uiTag, Weapon weapon, Armor armor, string role, Color color, Vector3 position)
    {
        // Player attributes
        player.Name = name;
        player.HealthPoints = health;
        player.ManaPoints = mana;
        player.CharacterWeapon = weapon;
        player.CharacterArmor = armor;
        player.Tag = uiTag;
        player.UpdateDefensStat();
        player.UpdateAttackStat();
        player.Role = role;
        player.Color = color;
        player.StartingPosition = position;

        // Add items of player to inventory pool
        Inventory.ItemList.Add(weapon);
        Inventory.ItemList.Add(armor);

        player.Initialize();
        CharManager.CharacterList.Add(player);
    }

    void CreateSpecificEnemy(Character.EnemyCharacter enemy, int health, int mana, int uiTag, Vector3 position)
    {
        // Enemy attributes
        enemy.Name = "Enemy";
        enemy.HealthPoints = health;
        enemy.ManaPoints = mana;
        enemy.StartingPosition = position;
        enemy.Tag = uiTag;
        enemy.CharacterWeapon = new Sword {AttackBonus = 60};
        enemy.CharacterArmor = new Armor(Armor.ArmorType.Helmet);
        enemy.UpdateDefensStat();
        enemy.UpdateAttackStat();

        enemy.Initialize();
        CharManager.EnemyList.Add(enemy);
    }

    public void UpdateCharacters(int deadPlayer)
    {
        // I don't remove characters from the character list so I have to check this way

        // check if player 1 is still alive
        if (GameObject.Find("Character1") && deadPlayer != 1)
        {
            Debug.Log("Found character 1");
            CharManager.UpdateCharacters(1);
        }

        // check if player 2 is still alive
        else if (GameObject.Find("Character2") && deadPlayer != 2)
        {
            Debug.Log("Found character 2");
            CharManager.UpdateCharacters(2);
        }

        // check if player 3 is still alive
        else if (GameObject.Find("Character3") && deadPlayer != 3)
        {
            Debug.Log("Found character 3");
            CharManager.UpdateCharacters(3);
        }
        else
        {
            CharacterManager.AllCharactersDied = true;
        }

        // Else game over
        if (CharacterManager.AllCharactersDied)
            EndGame(false);
    }

    public void CheckAliveEnemies()
    {
        // If there are no more enemies left, game won!
        if (CharManager.EnemyList.Count < 1)
            EndGame(true);
    }

    public void EndGame(bool hasWon)
    {
        // End game, show either lose or win screen and pauze game

        if (hasWon)
        {
            WinCanvas.SetActive(true);
            LoseCanvas.SetActive(false);
        }
        else
        {
            LoseCanvas.SetActive(true);
            WinCanvas.SetActive(false);
        }

        Time.timeScale = 0.0f;
    }
}
