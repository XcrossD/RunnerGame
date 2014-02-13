using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	
	private bool leftDetected, rightDetected;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(5f * Time.deltaTime, 0f, 0f);
		if(Input.GetKeyDown("a")){
			leftDetected = true;
			RotateLeft();
		}
		if(Input.GetKeyDown("d")){
			rightDetected = true;
			RotateRight();
		}
		
	}
	
	void RotateLeft(){
		transform.Rotate(Vector3.up, -90);
		leftDetected = false;
	}
	
	void RotateRight(){
		transform.Rotate(Vector3.up, 90);
		rightDetected = false;
	}
}
