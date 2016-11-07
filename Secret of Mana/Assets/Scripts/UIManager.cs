using UnityEngine;
using System.Collections;

public class UIManager
{
	public void Init ()
	{
        // Spawn canvas ( with panels )
        GameObject.Instantiate(Resources.Load("Prefabs/Panels"));
    }
}
