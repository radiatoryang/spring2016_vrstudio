using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class RigidbodyMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//InputTracking
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		if ( Input.GetKeyDown(KeyCode.R) ) {
			InputTracking.Recenter();
		}

		// var invokes "type inference" 
		// "type inference" is where C# guesses what type you meant
		// if it can't figure it out, it'll yell at you
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		var rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce( 0f, 0f, vertical * 100f );

		// bipedal turning
		// transform.Rotate( 0f, horizontal * Time.deltaTime * 100f, 0f );
	
		// physically-based turning
		rb.AddRelativeTorque( 0f, horizontal * 90f, 0f );
	}
}





