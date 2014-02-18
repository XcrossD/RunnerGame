using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
 
	public Camera FirstPersonCamera;
	public Camera ThirdPersonCamera;
	public Camera TopCamera;
 
	void Start () {
		FirstPersonCamera.enabled = false; 
		ThirdPersonCamera.enabled = true; 
		TopCamera.enabled= false;
	}
 
	void Update () {
		if (Input.GetKeyDown("2"))
		{
			FirstPersonCamera.enabled = false;
			ThirdPersonCamera.enabled = true;
			TopCamera.enabled= false;
		}
		if (Input.GetKeyDown("1"))
		{
			FirstPersonCamera.enabled = true;
			ThirdPersonCamera.enabled = false;
			TopCamera.enabled= false;
		}
		if (Input.GetKeyDown("3"))
		{
			FirstPersonCamera.enabled = true;
			ThirdPersonCamera.enabled = false;
			TopCamera.enabled= true;
		}
	}
}