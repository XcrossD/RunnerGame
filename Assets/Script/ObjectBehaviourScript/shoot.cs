using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

	// Use this for initialization
	public GameObject controller;
	public GameObject shot;
	public Light shotlight;
	private ShootingBehavior shotscript;
	
	void Start () {
		
		//initially disable the light and shot
		shot.SetActive(false);
		shotlight.enabled = false;
	}

	void Update () {
		//get the script for the variable assigned
		shotscript = shot.GetComponent<ShootingBehavior>();
		
		
		//shooting happen
		if (Input.GetKeyDown(KeyCode.F)){
			if (!shotscript.reloading){
			shot.SetActive(true);
			shotlight.enabled = true;
				
			//freezing the position
			controller.GetComponent<BasicMovement>().enabled = false;
			controller.GetComponent<MouseLook>().enabled = false;
			}
		}
		
		// shooting stop
		if (Input.GetKeyUp(KeyCode.F)){
			shot.SetActive(false);
			shotlight.enabled = false;
			shotscript.reset = true;
			shotscript.reloading = false;
			//release freezing and allow normal movement
			controller.GetComponent<BasicMovement>().enabled = true;
			controller.GetComponent<MouseLook>().enabled = true;
			
		}
	
	}

}
