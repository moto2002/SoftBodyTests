using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGravTests : MonoBehaviour {

	public GameObject target;
	Rigidbody rb;
	public float jumpForce;
	public float moveForce;
	float x;
	float y;

	void Start () {

		rb = GetComponent<Rigidbody> ();
		
	}
	

	void Update () {
		transform.LookAt (target.transform);
		x = Input.GetAxis ("Horizontal") * moveForce;
		y = Input.GetAxis ("Vertical") * moveForce;

		if (Input.GetButtonDown ("Jump")) {

			rb.AddRelativeForce (Vector3.forward * jumpForce);
		}

	}
	void FixedUpdate(){

		rb.AddRelativeForce (Vector3.right* y);
	}
}
