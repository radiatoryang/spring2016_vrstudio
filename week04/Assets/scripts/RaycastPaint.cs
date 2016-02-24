using UnityEngine;
using System.Collections;

public class RaycastPaint : MonoBehaviour {

	public Transform sphere; // assign in inspector
	
	// Update is called once per frame
	void Update () {
		// setting up our ray
		Ray ray = new Ray( Camera.main.transform.position,
						   Camera.main.transform.forward );
		// initializing a variable for later
		RaycastHit rayHitInfo = new RaycastHit();

		// actually shoot the raycast now
		if ( Physics.Raycast( ray, out rayHitInfo, 1000f ) ) {
			// move the sphere to where the raycast hit the cube
			Debug.DrawRay( ray.origin, ray.direction * rayHitInfo.distance, Color.yellow );
			// sphere.position = rayHitInfo.point; // point = world position of impact
			Instantiate( sphere, rayHitInfo.point, Quaternion.identity );
		}
	}
}
