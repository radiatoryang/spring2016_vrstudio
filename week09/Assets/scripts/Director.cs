using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	public Transform npcMoveTarget; // assign in Inspector
	public NavMeshAgent npcAgent; // assign in Inspector

	// Use this for initialization
	void Start () {
		// MyFirstCoroutine(); // DON'T DO THIS

		// you must always start a coroutine using StartCoroutine
		StartCoroutine( MyFirstCoroutine() );
	}
		
	// a Coroutine is a special kind of function that can
	// last more than 1 frame + we can control how fast it runs
	IEnumerator MyFirstCoroutine () {
		Debug.Log("the coroutine started!");
		yield return 0; // pause for a frame
		Debug.Log("ok, I waited for 1 frame, now continuing...");
		yield return 0;
		yield return 0; // waited for 2 frames
		Debug.Log("ok I waited 2 frames now!");

		// sometimes it's easier to wait for seconds, vs. counting frames
		yield return new WaitForSeconds(1.6f);
		Debug.Log("ok I waited for 1.6 seconds!");

		// move the NPC move target (a sphere? cylinder?) to control NPC
		npcMoveTarget.position = new Vector3( 0f, 0f, 2f );
		yield return new WaitForSeconds(5f);
		npcMoveTarget.position = new Vector3( 5f, 0f, -2f );

		// wait until I press SPACE before continuing...
		while ( !Input.GetKey(KeyCode.Space) ) {
			yield return 0;
		}
		// after we press space, the coroutine will continue...

		// we can also tell Unity to yield for the duration of a coroutine
		yield return StartCoroutine( WaitUntilDestination( Vector3.zero ) );

		// the coroutine is now finished, and will end
		Debug.Log("cutscene finished!");
	}

	IEnumerator WaitUntilDestination ( Vector3 newDestination ) {
		npcMoveTarget.position = newDestination;

		yield return new WaitForSeconds(2f); // thank you, terry

		// this code will keep waiting as long as Remaining Distance > 1.0f
		while ( npcAgent.remainingDistance > 1f ) {
			yield return 0;
		}
	}


}
