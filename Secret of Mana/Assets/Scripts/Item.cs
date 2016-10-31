using UnityEngine;
using System.Collections;

public abstract class Item {

    public enum ItemType
    {
        Collectable,
        Weapon
    }

    public ItemType ItemTypeMember;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
