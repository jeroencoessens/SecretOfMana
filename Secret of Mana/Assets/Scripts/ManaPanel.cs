﻿using UnityEngine;
using System.Collections;

public abstract class ManaPanel : MonoBehaviour {

    public bool ShouldOpen = false;

    public GameObject CurrentPanelObject;

    // Use this for initialization
    void Start () {
        CurrentPanelObject.SetActive(false);
    }

    public void RefreshPanel()
    {
        CurrentPanelObject.SetActive(ShouldOpen);
    }
}
