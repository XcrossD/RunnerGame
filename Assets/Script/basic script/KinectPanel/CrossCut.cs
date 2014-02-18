using UnityEngine;
using System.Collections;

public class CrossCut : MonoBehaviour {


	public Vector3 leftHandPosEnter;
	public Vector3 leftHandPosExit;
	public Vector3 rightHandPosEnter;
	public Vector3 rightHandPosExit;

	public GameObject leftHand;
	public GameObject rightHand;

	public int leftCutCount;
	public int rightCutCount;

	
	void Awake()
	{
		leftCutCount = 0;
		rightCutCount =0;

		
	}
	
	
	// Use this for initialization
	void Start () 
	{
		leftHand = GameObject.Find("left_hand");
		rightHand = GameObject.Find("right_hand");
	}

	
	
	//get the hand collider enter the panel
	void OnTriggerEnter(Collider hand)
	{
		if (hand.name == leftHand.name)
		{
			leftHandPosEnter= hand.transform.position;
			
		}

		if (hand.name == rightHand.name)
		{
			rightHandPosEnter= hand.transform.position;
			
		}


	}
	
	//get the hand collider exit the panel
	void OnTriggerExit(Collider hand)
	{
		if (hand.name == leftHand.name)
		{
			leftHandPosExit= hand.transform.position;
			LeftCrossCutCount();
		}
		if (hand.name == rightHand.name)
		{
			rightHandPosExit= hand.transform.position;
			RightCrossCutCount();
		}
		
	}
	
	void LeftCrossCutCount()
	{
		float distance = Vector3.Distance(leftHandPosEnter, leftHandPosExit);
		if (distance > 1f)
		{
			leftCutCount ++;
		}
	}

	void RightCrossCutCount()
	{
		float distance = Vector3.Distance(rightHandPosEnter, rightHandPosExit);
		if (distance > 1f)
		{
			rightCutCount ++;
		}


	}

}
