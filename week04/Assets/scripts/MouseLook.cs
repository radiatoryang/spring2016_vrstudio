using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		// GetAxis returns a number between -1 and 1
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		// rotate the camera
		transform.Rotate( -mouseY * Time.deltaTime * 180f, mouseX * Time.deltaTime * 180f, 0f );

		// corrective pass: unroll the camera
		transform.localEulerAngles = new Vector3( transform.localEulerAngles.x,
												  transform.localEulerAngles.y,
			                                      0f );
	}
}
