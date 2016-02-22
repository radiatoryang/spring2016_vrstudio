using UnityEngine;
using System.Collections;

public class RaycastTrigger : MonoBehaviour {

	bool wasLooking = false; // used for OnStartLook and OnEndLook
	
	// Update is called once per frame
	void Update () {
		// generate the ray before we raycast it
		Ray ray = new Ray( Camera.main.transform.position,
						   Camera.main.transform.forward );
		// this var will tell us where and what it hit
		RaycastHit rayHitInfo = new RaycastHit();

		Debug.DrawRay( ray.origin, ray.direction * 1000f, Color.yellow );
	
		// actually shooting the raycast now
		if ( Physics.Raycast( ray, out rayHitInfo, 1000f ) 
			 && rayHitInfo.transform == this.transform ) {
			// is the raycast hitting the thing we put this script on?
			OnLooking();
			if ( wasLooking == false ) {
				wasLooking = true;
				OnStartLook();
			}
		} else {
			OnNotLooking();
			if ( wasLooking == true ) {
				wasLooking = false;
				OnEndLook();
			}
		}

	}

	// code that will happen when I start looking at something
	void OnStartLook () {

	}

	// code that will happen the instant when I stopped looking at something
	void OnEndLook () {

	}

	// code that will happen CONSTANTLY as long as we're looking at it
	void OnLooking () {
		transform.Rotate(0f, 15f, 0f);
		// turn red over time as long as we keep looking at it
		GetComponent<Renderer>().material.color = Color.Lerp( GetComponent<Renderer>().material.color,
															  Color.red,
															  Time.deltaTime * 0.5f);
	}

	// code that will happen CONSTANTLY when we are NOT looking at it
	void OnNotLooking () {
		transform.localScale *= 1.001f; // get bigger 101% of current size
	}



}
