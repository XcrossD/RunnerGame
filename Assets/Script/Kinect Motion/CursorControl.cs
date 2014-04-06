using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	float sensitivityX;
	float sensitivityY;
	MouseControl mouseCon;


	public int cursorX = Screen.width;
	public int cursorY = Screen.height;
	public int targetX = Screen.width;
	public int targetY = Screen.height;
	public bool rightIsIn= false;
	Vector3 spinePos;
	float spineX;
	float spineY;

	public float Zpos = 0;


	// Use this for initialization
	void Start () {
		mouseCon =	gameObject.GetComponent<MouseControl>();
	}
	


	void OnTriggerEnter(Collider other)
	{
		if (other.name == "right_hand")
		{
			rightIsIn = true;
			spinePos = GameObject.Find("spine").transform.position;
			spineX = spinePos.x;
			spineY = spinePos.y;
			//set show cursor to false to reset the cursor state
			mouseCon.showCursor=false;
			mouseCon.CursorShow();
		}
		else if (other.name == "left_hand" && !rightIsIn)
		{

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "right_hand")
		{
			//hind the cursor when hand is off from the panel
			mouseCon.showCursor = false;

			//put the cursor back to center
			mouseCon.cursorpos.x= Screen.width/2;
			mouseCon.cursorpos.y= Screen.height/2;
			//prevent left hand to control;
			rightIsIn = false;
		}

	}

	void OnTriggerStay(Collider other)
	{
		if (other.name == "right_hand") 
		{
			Zpos=other.transform.position.z;

			sensitivityX = Screen.width;
			sensitivityY = Screen.height;

			mouseCon = gameObject.GetComponent<MouseControl>();
			cursorX = mouseCon.cursorpos.x ;
			cursorY = mouseCon.cursorpos.y ;

			//set the target position for the cursor to move 
			targetX = Mathf.FloorToInt((other.transform.position.x - spineX) * sensitivityX) + Screen.width/2 - Screen.width/3;
			targetY = Mathf.FloorToInt((-other.transform.position.y + spineY -0.2f) * sensitivityY) + Screen.height;
			//control the mouse control script to set the cursor icon position

			mouseCon.cursorpos.x = Mathf.FloorToInt(Mathf.Lerp(cursorX, targetX, 1));
			mouseCon.cursorpos.y = Mathf.FloorToInt(Mathf.Lerp(cursorY, targetY, 1));
		}

	}



}
