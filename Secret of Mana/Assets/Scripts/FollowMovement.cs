using UnityEngine;
using System.Collections;

public class FollowMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

	void Start ()
	{
	    _agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
	{
	    if (CharacterManager.SelectedCharacter != null && !CharacterManager.AllCharactersDied)
	        _agent.destination = CharacterManager.SelectedCharacter.GetPosition();
	}
}
