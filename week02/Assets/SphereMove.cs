using UnityEngine;
using System.Collections;

public class SphereMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// move 10 units on X axis per second
		// Time.deltaTime makes this framerate independent
		transform.position += new Vector3(10f, 0f, 0f) * Time.deltaTime;

		// teleport sphere back into the room if it goes too far
		if ( transform.position.x > 37f ) {
			transform.position = new Vector3( -37f, 2f, 5f );
		}
	}
}
