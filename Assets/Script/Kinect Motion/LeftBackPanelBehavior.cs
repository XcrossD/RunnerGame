using UnityEngine;
using System.Collections;

public class LeftBackPanelBehavior : MonoBehaviour {
	
	public Collider rightHandCollider;
	public Collider leftHandCollider;
	public GameObject robot;
	private float moveSpeed = 5f;
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Left back panel is ready");
		
		//get the robot's movespeed
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//command from the hand detection
	void OnTriggerStay(Collider handCollider){
		if (handCollider.name == rightHandCollider.name){
			//Debug.Log("Right hand is detected is detect in left hand back panel");

		}
		
		if (handCollider.name == leftHandCollider.name){
			//Debug.Log("left hand is detected is detect in left hand back panel");
			robot.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
			robot.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		}
		
		
		
		
	}
}
