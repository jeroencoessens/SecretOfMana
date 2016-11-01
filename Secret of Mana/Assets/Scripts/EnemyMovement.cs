using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

	// Use this for initialization
	void Start ()
	{
	    _agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonUp(0))
	    {
	        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        RaycastHit hitInfo;

	        if (Physics.Raycast(ray, out hitInfo))
	        {
	            _agent.destination = hitInfo.point;
	        }
	    }
	}
}
