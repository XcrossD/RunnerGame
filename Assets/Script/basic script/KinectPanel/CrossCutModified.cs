using UnityEngine;
using System.Collections;

public class CrossCutModified : MonoBehaviour {


	public Vector3 leftHandPosEnter;
	public Vector3 leftHandPosExit;
	public Vector3 rightHandPosEnter;
	public Vector3 rightHandPosExit;

	//public GameObject leftHand;
	//public GameObject rightHand;
	public GameObject runner;

	public Collider rightHandCollider;
	public Collider leftHandCollider;

	public bool on;

	public KeyMapping kM;

	
	// Use this for initialization
	void Start () 
	{
		//leftHand = GameObject.Find("left_hand");
		//rightHand = GameObject.Find("right_hand");
		on = false;

	}

	
	
	//get the hand collider enter the panel
	void OnTriggerEnter(Collider hand)
	{
		if (hand.name == leftHandCollider.name)
		{
			leftHandPosEnter= hand.transform.position;
			
		}

		if (hand.name == rightHandCollider.name)
		{
			rightHandPosEnter= hand.transform.position;
			
		}


	}
	
	//get the hand collider exit the panel
	void OnTriggerExit(Collider hand)
	{
		if (hand.name == leftHandCollider.name)
		{
			leftHandPosExit= hand.transform.position;
			RotateLeft();
		}
		if (hand.name == rightHandCollider.name)
		{
			rightHandPosExit= hand.transform.position;
			RotateRight();
		}
		
	}
	
	void RotateLeft()
	{
		float distance = Vector3.Distance(leftHandPosEnter, leftHandPosExit);
		if (distance > 1f)
		{
			//runner.transform.Rotate(Vector3.up, -90);
			if(on){
				kM.RotationChanging(false);
			}
		}
	}

	void RotateRight()
	{
		float distance = Vector3.Distance(rightHandPosEnter, rightHandPosExit);
		if (distance > 1f)
		{
			//runner.transform.Rotate(Vector3.up, 90);
			if(on){
				kM.RotationChanging(true);
			}
		}


	}

}
