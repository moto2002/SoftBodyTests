using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour {

	public Rigidbody rb;
	public float number;
	public Vector3 rbAngularVelocity;


	void Start () {

	}
	

	void Update () {


		rb.gameObject.transform.Translate (0, number*Time.deltaTime,0);
		/*rb.maxAngularVelocity = 10000000;
		rb.AddRelativeTorque(0,number,0);
		rbAngularVelocity = rb.angularVelocity;*/
	}

	void Blah(float anotherNumber){

		number = anotherNumber;

	}
}
