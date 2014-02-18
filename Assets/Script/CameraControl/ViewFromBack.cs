using UnityEngine;
using System.Collections;

public class ViewFromBack : MonoBehaviour {

	public Camera mainCamera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			backCameraSwitch();

		}	
	}

	void backCameraSwitch()
	{
		if (camera.enabled == false)
		{
			camera.enabled = true;
			mainCamera.enabled= false;
		}
		else
		{
			mainCamera.enabled= true;
			camera.enabled = false;


		}


	}

}
