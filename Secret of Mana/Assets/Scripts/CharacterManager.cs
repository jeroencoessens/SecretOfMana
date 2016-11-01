using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterManager {

    public static List<Character.PlayerCharacter> CharacterList = new List<Character.PlayerCharacter>();
    public static List<Character.EnemyCharacter> EnemyList = new List<Character.EnemyCharacter>();

    public static Character.PlayerCharacter SelectedCharacter;

    // Use this for initialization
    public void Init () {

        TestCharacters();
    }
	
	// Update is called once per frame
	public void Update () {

	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        SelectedCharacter = CharacterList[0];
	    }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedCharacter = CharacterList[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedCharacter = CharacterList[2];
        }
    }

    // only for testing !!
    void TestCharacters()
    {
        // default character for testing
        var eddy = new Character.PlayerCharacter();
        eddy.Name = "Eddy";
        eddy.CharacterWeapon = new Sword();
        eddy.CharacterArmor = new Armor();
        eddy.CharacterArmor.ArmorPiece = Armor.ArmorType.Helmet;
        CharacterList.Add(eddy);

        // default character 2 for testing
        var barry = new Character.PlayerCharacter();
        barry.Name = "Barry";
        barry.CharacterWeapon = new Bow();
        barry.CharacterArmor = new Armor();
        barry.CharacterArmor.ArmorPiece = Armor.ArmorType.Chestplate;
        barry.Tag = 2;
        CharacterList.Add(barry);

        // default character 3 for testing
        var gandalf = new Character.PlayerCharacter();
        gandalf.Name = "Gandalf";
        gandalf.CharacterWeapon = new Staff();
        gandalf.CharacterArmor = new Armor();
        gandalf.CharacterArmor.ArmorPiece = Armor.ArmorType.Pants;
        gandalf.Tag = 3;
        CharacterList.Add(gandalf);

        SelectedCharacter = CharacterList[0];

        foreach (var character in CharacterList)
        {
            Debug.Log("Characterlist contains " + character.Name);
        }
    }
}
