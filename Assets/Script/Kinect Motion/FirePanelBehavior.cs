using UnityEngine;
using System.Collections;

public class FirePanelBehavior : MonoBehaviour {
	
	public Collider rightHandCollider;
	public Collider leftHandCollider;
	public GameObject movementPanel;
	public GameObject robot;
	
	//for fire script
	public GameObject shot;
	public Light shotlight;
	private ShootingBehavior shotscript;
	
	
	
	// Use this for initialization
	void Start () {
		Debug.Log("Fire panel is ready");
		//initially disable the light and shot
		shot.SetActive(false);
		shotlight.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//command from the hand detection
	void OnTriggerEnter(Collider handCollider){
		
		shotscript = shot.GetComponent<ShootingBehavior>();
		
		if (handCollider.name == rightHandCollider.name){
			Debug.Log("Right hand is detected is detect in Fire panel");	
			Fire(shotscript);

		}
		
		if (handCollider.name == leftHandCollider.name){
			Debug.Log("left hand is detected is detect in Fire panel");
			Fire(shotscript);
		}
	}	
	
	
	
	//send fire command
	void Fire(ShootingBehavior script){
		
		//shooting happen
		if (!script.reloading){
			shot.SetActive(true);
			shotlight.enabled = true;
				
			//freezing the position
			robot.GetComponent<BasicMovement>().enabled = false;
			robot.GetComponent<MouseLook>().enabled = false;
			movementPanel.SetActive(false);
			
		}
		


	}
	
	
	// call stop fire function when hand is down
	void OnTriggerExit(Collider handCollider){
		
		shotscript = shot.GetComponent<ShootingBehavior>();
		
		if (handCollider.name == rightHandCollider.name){
			Debug.Log("Right hand is off from the Fire panel");	
			FireOff(shotscript);

		}
		
		if (handCollider.name == leftHandCollider.name){
			Debug.Log("left hand is off from the Fire panel");
			FireOff(shotscript);
		}
		
		
	}
		
	//command -- stop fire	
	void FireOff(ShootingBehavior script){	
		// shooting stop
			shot.SetActive(false);
			shotlight.enabled = false;
			script.reset = true;
			script.reloading = false;
			//release freezing and allow normal movement
			robot.GetComponent<BasicMovement>().enabled = true;
			robot.GetComponent<MouseLook>().enabled = true;	
			movementPanel.SetActive(true);
		
		
	}
}
