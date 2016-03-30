using UnityEngine;
using System.Collections;

public class DanceLayerDemo : MonoBehaviour {

	Animator myAnimator;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// press [SPACE] to control dancing layer
		// make sure the dancing layer is set to "additive"
		if ( Input.GetKey(KeyCode.Space) ) {
			// set DanceLayer weight to 1
			myAnimator.SetLayerWeight(1, 1f);
		} else {
			// set DanceLayer weight to 0
			myAnimator.SetLayerWeight(1, 0f);
		}
	}
}
