using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererPositions : MonoBehaviour {

	LineRenderer line;
	public GameObject target;

	void Start () {

		line = GetComponent<LineRenderer> ();
	}

	void Update () {
		line.SetPosition(0, transform.position);
		line.SetPosition(1, target.transform.position);

	}
}
