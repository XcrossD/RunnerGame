using UnityEngine;
using System.Collections;

public class KeyMapping : MonoBehaviour {

	public GameObject runner;
	public PlatformManager pM;
	public Vector3 newPositionLeft, newPositionRight, oldPosition, newPosition;
	public float turnPosition, checkPosition;
	public bool isRight, isLeft, inputRight;
	public Quaternion rightRotation, leftRotation;

	// Use this for initialization
	void Start () {
		isRight = false;
		isLeft = false;

	}
	
	// Update is called once per frame
	void Update () {
		//PositionChanging();
		//RotationChanging();
		if(Input.GetKeyDown(KeyCode.Q)){
			inputRight = false;
			RotationChanging(inputRight);
		}

	}

	public void PositionChanging(bool inputRight){

		oldPosition = runner.transform.localPosition;
		if(Vector3.Dot(runner.transform.forward, Vector3.forward) == 0){
			if(isRight){
				newPositionRight = oldPosition;
				oldPosition.z -= 2.5f;
				newPositionLeft = oldPosition;
			}else if(isLeft){
				newPositionLeft = oldPosition;
				oldPosition.z += 2.5f;
				newPositionRight = oldPosition;
			}else{
				oldPosition.z += 2.5f;
				newPositionRight = oldPosition;
				oldPosition.z -= 5f;
				newPositionLeft = oldPosition;
			}
		}else{
			if(isRight){
				newPositionRight = oldPosition;
				oldPosition.x -= 2.5f;
				newPositionLeft = oldPosition;
			}else if(isLeft){
				newPositionLeft = oldPosition;
				oldPosition.x += 2.5f;
				newPositionRight = oldPosition;
			}else{
				oldPosition.x += 2.5f;
				newPositionRight = oldPosition;
				oldPosition.x -= 5f;
				newPositionLeft = oldPosition;
			}
		}
		
		if(!inputRight || Input.GetKeyDown(KeyCode.A)){
			runner.rigidbody.MovePosition(newPositionLeft);
			if(isRight){
				isRight = false;
			}else{
				isLeft = true;
			}

		}
		if(inputRight || Input.GetKeyDown(KeyCode.D)){
			runner.rigidbody.MovePosition(newPositionRight);
			if(isLeft){
				isLeft = false;
			}else{
				isRight = true;
			}
		}
	}
	

	public void RotationChanging(bool inputRight){
		BasicMovementForEthan ethan = runner.GetComponent<BasicMovementForEthan>();
		if(!inputRight){
		
			Debug.Log("turn left");
			Vector3 newSpeed = Vector3.Cross (ethan.speed,new Vector3(0,1,0));
			runner.rigidbody.MoveRotation(Quaternion.FromToRotation(ethan.speed,newSpeed));
			Debug.Log(ethan.speed);
			Debug.Log (newSpeed);
			Debug.Log (Quaternion.FromToRotation(ethan.speed,newSpeed));
			ethan.speed = newSpeed;
			
		}else{
			Vector3 newSpeed = Vector3.Cross (new Vector3(0,1,0),ethan.speed);
			runner.rigidbody.MoveRotation(Quaternion.FromToRotation(ethan.speed,newSpeed));
			ethan.speed = newSpeed;
		}
	}
}
