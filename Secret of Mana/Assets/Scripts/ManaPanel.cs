using UnityEngine;
using System.Collections;

public abstract class ManaPanel : MonoBehaviour {

    public bool ShouldOpen = false;
    public GameObject CurrentPanelObject;

    void Start ()
    {
        CurrentPanelObject.SetActive(false);
    }

    public void RefreshPanel()
    {
        CurrentPanelObject.SetActive(ShouldOpen);
    }
}
