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
        var persueClosest = false;

        // enemies can persue closest character instead of selected character
	    if (CompareTag("Enemy"))
	    {
	        foreach (var character in GameManager.CharManager.CharacterList)
	        {
	            // distance between this enemy and current looped character ( from list )
	            var distance = Vector3.Distance(transform.position, character.GetPosition());

	            // if close enough, just persue that character instead of selected character
	            if (distance < 2.5f)
	            {
	                persueClosest = true;
	                _agent.destination = character.GetPosition();
	            }

	            // if enemy found a close enough character, no need to loop again, persue this character
	            if (persueClosest)
	                return;
	        }
	    }
	    
        if(!persueClosest)
	    {
            // Basic movement, follow selected player
            if (CharacterManager.SelectedCharacter != null && !CharacterManager.AllCharactersDied)
                _agent.destination = CharacterManager.SelectedCharacter.GetPosition();
        }
	}
}
