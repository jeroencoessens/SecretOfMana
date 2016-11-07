using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	void Start ()
	{
	    Destroy(gameObject, 3.0f);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Level"))
            Destroy(gameObject);
    }
}
