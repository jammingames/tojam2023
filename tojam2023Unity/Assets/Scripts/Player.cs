using Mono.Cecil.Rocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    
    bool isDropping = false;
    Rock currentlyHeldRock= null;
    private void MoveRock()
    {
        isDropping = true;
    }

    private void DropRock() { }
    private void PickupRock() { }//Rock interface param goes here) { }
    private void DoRockLogic() { }

	private void Update()
	{
        if (GameManager.instance.currentState != GameState.Game) return;
	    if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            //placeholder for interaction with dragging moving dropping etc
            DoRockLogic();
        }
	}

}
