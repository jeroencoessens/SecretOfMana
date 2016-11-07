using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public void Load(int buildIndex)
    {
        // Load correct scene
        SceneManager.LoadScene(buildIndex);
    }
}
