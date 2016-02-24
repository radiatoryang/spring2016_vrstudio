using UnityEngine;
using System.Collections;

using UnityEngine.VR;

public class VRUtility : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false; // hides the cursor
		Cursor.lockState = CursorLockMode.Locked; // lock the cursor in middle of screen
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(KeyCode.RightBracket) ) { // increase visual quality
			VRSettings.renderScale = Mathf.Clamp01( VRSettings.renderScale + 0.1f);
		}
		if ( Input.GetKeyDown(KeyCode.LeftBracket) ) { // decrease visual quality
			VRSettings.renderScale = Mathf.Clamp01( VRSettings.renderScale - 0.1f);
		}

		if ( Input.GetKeyDown(KeyCode.R) ) { // reset VR HMD's orientation
			InputTracking.Recenter();
		}
	}
}
