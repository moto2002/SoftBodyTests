﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour {

	public GameObject _dot;
	public float _degree, _c;
	public int _n;
	public float _dotScale;
	private Vector2 CalculatePhyllotaxis (float degree, float scale, int count)
	{
		double angle = count * (degree * Mathf.Deg2Rad);
		float r = scale * Mathf.Sqrt (count);
		float x = r * (float)System.Math.Cos (angle);
		float y = r * (float)System.Math.Sin (angle);
		Vector2 vec2 = new Vector2 (x, y);
		return vec2;
	}
	private Vector2 _phyllotaixPosition;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space))
		{
			_phyllotaixPosition = CalculatePhyllotaxis (_degree, _c, _n);
			GameObject dotInstance = (GameObject)Instantiate (_dot);
			dotInstance.transform.position = new Vector3 (_phyllotaixPosition.x, _phyllotaixPosition.y, 0);
			dotInstance.transform.localScale = new Vector3 (_dotScale, _dotScale, _dotScale);
			_n++;
		}
		
	}
}
