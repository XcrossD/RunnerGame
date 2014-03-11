using UnityEngine;
using System.Collections;

public class RightBackPanelBehavior : MonoBehaviour {
	
	public Collider rightHandCollider;
	public Collider leftHandCollider;
	public GameObject robot;
	private float moveSpeed = 5f;
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Right back panel is ready");
		
		//get the robot's movespeed
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//command from the hand detection
	void OnTriggerStay(Collider handCollider){
		if (handCollider.name == rightHandCollider.name){
			//Debug.Log("Right hand is detected is detect in right hand back panel");
			//robot.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
			//robot.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

		}
		
		if (handCollider.name == leftHandCollider.name){
			//Debug.Log("left hand is detected is detect in right hand back panel");

		}
		
		
		
		
	}
}
