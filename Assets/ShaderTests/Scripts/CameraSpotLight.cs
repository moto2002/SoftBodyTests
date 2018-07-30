using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpotLight : MonoBehaviour {

	public Material Mat;

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, Mat);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

