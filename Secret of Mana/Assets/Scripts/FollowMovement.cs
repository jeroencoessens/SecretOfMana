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
        // Basic movement, follow selected player
	    if (CharacterManager.SelectedCharacter != null && !CharacterManager.AllCharactersDied)
	        _agent.destination = CharacterManager.SelectedCharacter.GetPosition();
	}
}
