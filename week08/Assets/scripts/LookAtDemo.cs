using UnityEngine;
using System.Collections;

public class LookAtDemo : MonoBehaviour {

	Animator animator;
	public Transform lookTarget;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void OnAnimatorIK () {
		// visualizing what SHOULD be happening
		Debug.DrawLine( animator.GetBoneTransform( HumanBodyBones.Head ).position,
						lookTarget.position,
						Color.yellow );
		// set the look target
		animator.SetLookAtPosition( lookTarget.position );
		animator.SetLookAtWeight( 1f, 1f );
	}
}
