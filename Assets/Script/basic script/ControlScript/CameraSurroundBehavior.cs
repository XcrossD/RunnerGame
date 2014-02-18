using UnityEngine;
using System.Collections;

public class CameraSurroundBehavior : MonoBehaviour {
	
	public GameObject rotateAroundThis ;
	public int sensitivity = 100;
	public float minDistance;
	Vector3 IniPosition;
	Quaternion IniRotation;
	
	
	void Start () {
		
		minDistance= Mathf.Abs(transform.localPosition.z) -6f;
		IniPosition = transform.localPosition;
		IniRotation = transform.localRotation;
	
	}
	
	// Update is called once per frame
	void Update () {
		WaitforRotateKey();
	}
	
	
	void WaitforRotateKey(){
		//anti clockwise rotate
		if (Input.GetKey(KeyCode.LeftArrow)){
			RotateLeft();
			
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			RotateRight();
			
		}
		
		if (Input.GetKey(KeyCode.UpArrow)){
			Zoomin();
			
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			ZoomOut();
			
		}
		
		if (Input.GetKeyDown("2")){
			ResetCameraPosition();
			
		}
		
	}
	
	void RotateLeft(){
		
		Vector3 centerposition = rotateAroundThis.transform.position;
		
		
		//Vector3 newposition = Transform.position;
		//Vector3 nowposition = newposition;
		
		
			
		//adjust the angel
		transform.RotateAround(centerposition, Vector3.up,  sensitivity* Time.deltaTime);
		
		
	}
	void RotateRight(){
		Vector3 centerposition = rotateAroundThis.transform.position;
		transform.RotateAround(centerposition, Vector3.down,  sensitivity* Time.deltaTime);
		
	}
	
	
	void Zoomin(){
		
		if (FurtherThanMinDistance()){
			transform.Translate(Vector3.forward * sensitivity/10 * Time.deltaTime);
		}
		
	}
	
	//preventing the camera get too close
	bool FurtherThanMinDistance(){
		bool larger = ( Mathf.Abs(transform.localPosition.z) > minDistance);
		return larger;
		
		
	}
	
	
	
	void ZoomOut(){
		transform.Translate(Vector3.back * sensitivity/10 * Time.deltaTime);
		
		
	}
	void ResetCameraPosition(){
		transform.localPosition = IniPosition;
		transform.localRotation = IniRotation;
	}
}
