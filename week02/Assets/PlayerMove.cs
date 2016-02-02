using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// returns value from -1f to 1f based on virtual joystick
		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		// move forward and backward
		transform.Translate( 0f, 0f, vertical * Time.deltaTime * 10f );

		// turn the player
		transform.Rotate( 0f, horizontal * Time.deltaTime * 100f, 0f );
	}
}
