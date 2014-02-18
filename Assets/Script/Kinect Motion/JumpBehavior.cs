using UnityEngine;
using System.Collections;

public class JumpBehavior : MonoBehaviour {
	
	public Collider rightHandCollider;
	public Collider leftHandCollider;
	public GameObject movementPanel;
	public GameObject robot;
	public float jumpforce = 40000;
	public bool isjumping = false;
	
	
	// Use this for initialization
	void Start () {
		Debug.Log("Jump panel is ready");

		
	}
	
	// Update is called once per frame
	void Update () {
		
		LandedCheck();
		SpaceJump();
	}
	
	//command from the hand detection
	void OnTriggerEnter(Collider handCollider){
		
		if (handCollider.name == rightHandCollider.name){
			Debug.Log("Right hand is detected is detect in Jump panel");
			Jump ();

		}
		
		if (handCollider.name == leftHandCollider.name){
			Debug.Log("left hand is detected is detect in Jump panel");
			Jump ();

		}
	}	
	
	
	void Jump(){
		if (!isjumping){
			DoJump();
		}
	}
	
	
	void DoJump(){
		robot.rigidbody.AddForce(Vector3.up * jumpforce); 
		Debug.Log("The robot jumped");
		isjumping = true;
	}
	
	void LandedCheck(){

		if (robot.transform.localPosition.y < 1){
			Debug.Log("The robot is landed");
			isjumping = false;
		}
	
		
	}
	
	void SpaceJump(){
		if (Input.GetKey(KeyCode.Space)){
			Jump();
			
		}
		
		
	}
	
	
}
