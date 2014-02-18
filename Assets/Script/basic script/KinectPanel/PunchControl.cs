using UnityEngine;
using System.Collections;

public class PunchControl : MonoBehaviour {

	public string leftPunchLevel = "ready" ;  //punch level can reach at max 3. level 0 is not yet punched
	public string rightPunchLevel = "ready";

	//{"ready", "light", "normal", "heavy"}
	private PunchingBehavior lightPunch;		//to store the script
	private PunchingBehavior normalPunch;
	private PunchingBehavior heavyPunch;

	public int leftHeavy;		//store the hit count
	public int leftNormal;
	public int leftLight;
	public int rightHeavy;
	public int rightNormal;
	public int rightLight;

	public bool lResetting= false;
	public bool rResetting= false;

	void Awake(){
		lightPunch = GameObject.Find ("Punch Panel layer 1").GetComponent<PunchingBehavior>();
		normalPunch = GameObject.Find ("Punch Panel layer 2").GetComponent<PunchingBehavior>();
		heavyPunch = GameObject.Find ("Punch Panel layer 3").GetComponent<PunchingBehavior>();
		leftHeavy = heavyPunch.leftHitCount;
		leftNormal = normalPunch.leftHitCount;
		leftLight = lightPunch.leftHitCount;
		rightHeavy = heavyPunch.rightHitCount;
		rightNormal = normalPunch.rightHitCount;
		rightLight = lightPunch.rightHitCount;
	}

	void Start(){
		//InvokeRepeating("ResetLeftPunchCount", 60f, 1f);

	}

	// Update is called once per frame
	void Update () {

		//update the punch count on each panel
		leftHeavy = heavyPunch.leftHitCount;
		leftNormal = normalPunch.leftHitCount;
		leftLight = lightPunch.leftHitCount;
		rightHeavy = heavyPunch.rightHitCount;
		rightNormal = normalPunch.rightHitCount;
		rightLight = lightPunch.rightHitCount;

		leftFindLevel();
		rightFindLevel();

	}

	void leftFindLevel(){
		//determine the left punch level
		if (Mathf.Max(leftHeavy, leftNormal, leftLight)== leftHeavy){
			leftPunchLevel = "heavy";
		}
		else if (Mathf.Max(leftNormal, leftLight)== leftNormal){
			leftPunchLevel = "normal";
		}
		else if (leftLight>0){
			leftPunchLevel = "light";
		};
		
		//reset to find the punch level
		if (Mathf.Max(leftHeavy, leftNormal, leftLight)== 0){
			leftPunchLevel = "ready";
			lResetting = false;
		}
		else if (!lResetting) {
			//reset the level determine
			Invoke("ResetLeftPunchCount", 5f);
			lResetting = true;
		}
	}

	void rightFindLevel(){
		//determine the right punch level
		if (Mathf.Max(rightHeavy, rightNormal, rightLight)== rightHeavy){
			rightPunchLevel = "heavy";
		}
		else if (Mathf.Max(rightNormal, rightLight)== rightNormal){
			rightPunchLevel ="normal";
		}
		else if (rightLight>0){
			rightPunchLevel ="light";
		};
		
		//reset to find the punch level
		if (Mathf.Max(rightHeavy, rightNormal, rightLight)== 0){
			rightPunchLevel = "ready";
			rResetting = false;
		}
		else if (!lResetting) {
			//reset the level determine
			Invoke("ResetRightPunchCount", 5f);
			rResetting = true;
		}



	}

	//reset count functions
	void ResetLeftPunchCount(){
		lightPunch.leftHitCount = 0;
		normalPunch.leftHitCount = 0;
		heavyPunch.leftHitCount = 0;
		lResetting = false;

	}
	void ResetRightPunchCount(){
		lightPunch.rightHitCount = 0;
		normalPunch.rightHitCount = 0;
		heavyPunch.rightHitCount = 0;
		rResetting = false;
		
	}


}
