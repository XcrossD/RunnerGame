using UnityEngine;
using System.Collections;

public class PunchingBehavior : MonoBehaviour {

	//for both hands

	private GameObject lefthand;	//define the left and right hand
	private GameObject righthand;	
	public int leftHitCount = 0;	//counting the left and right hand hit on the panel
	public int rightHitCount = 0 ;


	void Awake ()
	{
		//setting for reference
		lefthand = GameObject.Find("left_hand");
		righthand = GameObject.Find("right_hand");
	}
	
	// Use this for initialization
	void Start () {
		Debug.Log("Punch panel is ready");

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//command from the hand detection
	void OnTriggerEnter(Collider handCollider){
		
		if (handCollider.name == lefthand.name){
			Debug.Log("Left hand is detected is detect in Punch panel");	
			leftHitCount += 1;

		}
		
		if (handCollider.name == righthand.name){
			Debug.Log("Right hand is detected is detect in Punch panel");
			rightHitCount += 1;
		}
	}	
	

	// call stop fire function when hand is down
	void OnTriggerExit(Collider handCollider){

		if (handCollider.name == lefthand.name){
			Debug.Log("Left hand is off from the Punch panel");	
			leftHitCount+= 1;

		}
		
		if (handCollider.name == righthand.name){
			Debug.Log("Right hand is off from the Punch panel");
			rightHitCount += 1;
		}
		
		
	}
}
