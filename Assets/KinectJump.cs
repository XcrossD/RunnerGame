using UnityEngine;
using System.Collections;

public class KinectJump : MonoBehaviour {
	
	public Collider kneeCollider;

	public GameObject movementPanel;
	public GameObject robot;


	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.


	void Awake(){
		anim = robot.GetComponent<Animator>();
		hash = GetComponent<HashIDs>();

	}


	// Use this for initialization
	void Start () {
		Debug.Log("KinectJump panel is ready");
		
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	//command from the hand detection
	void OnTriggerEnter(Collider other){
		Debug.Log("knee "+kneeCollider.name);
		Debug.Log("other's "+other.name);
		if (other.name == kneeCollider.name){
			Debug.Log("knee collidor is detected in Jump panel");
			robot.GetComponent<BasicMovementForEthan>().KinectJump=true;

			//robot.GetComponent<Animator>().SetBool(hash.jumpBool, true);
			  //make ethan jump
			//Jump();
			
		}
		

	}	
	
	void OnTriggerExit(Collider other){
		if (other.name == kneeCollider.name){

			Debug.Log("knee collidor is detected exit the Jump panel");
			robot.GetComponent<BasicMovementForEthan>().KinectJump=false;
			
		}



	}
		


	void Jump(){


	}
	

	
	
}
