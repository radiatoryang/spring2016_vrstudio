using UnityEngine;
using System.Collections;

using UnityEngine.VR;

public class CharacterMove : MonoBehaviour {

	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.R) ) { // let user recenter camera if they want to
			InputTracking.Recenter();
		}

		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		// move forward in the direction that the VR headset is looking
		controller.Move( vertical * Camera.main.transform.forward * Time.deltaTime * 10f + Physics.gravity);
		// turn left or right
		transform.Rotate( 0f, horizontal * Time.deltaTime * 100f, 0f );
	}
}
