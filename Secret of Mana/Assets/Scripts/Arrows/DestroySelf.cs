﻿using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	void Start ()
	{
	    Destroy(gameObject, 2.0f);
	}
}
