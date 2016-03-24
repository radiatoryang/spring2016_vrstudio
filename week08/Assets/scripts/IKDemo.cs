using UnityEngine;
using System.Collections;

public class IKDemo : MonoBehaviour {

	Animator animator;
	public Transform ikTarget; // the "goal" to solve towards
	public AvatarIKGoal ikType; // LeftHand? RightHand? LeftFoot? RightFoot?

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void OnAnimatorIK () { // all IK functions must go inside OnAnimatorIK
		animator.SetIKPosition( ikType, ikTarget.position );
		animator.SetIKPositionWeight( ikType, 1f );
		animator.SetIKRotation( ikType, ikTarget.rotation );
		animator.SetIKRotationWeight( ikType, 1f );
	}

}
