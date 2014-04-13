using UnityEngine;
using System.Collections;

public class KeyMapping : MonoBehaviour {

	public GameObject runner;
	public PlatformManager pM;
	public Vector3 newPositionLeft, newPositionRight, oldPosition, newPosition;
	public float turnPosition, checkPosition;
	public bool isRight, isLeft, rotationInputRight, positionInputRight;
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
			rotationInputRight = false;
			RotationChanging(rotationInputRight);
		}

		if(Input.GetKeyDown(KeyCode.E)){
			rotationInputRight = true;
			RotationChanging(rotationInputRight);
		}

		if(Input.GetKeyDown(KeyCode.A)){
			positionInputRight = false;
			PositionChanging(positionInputRight);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			positionInputRight = true;
			PositionChanging(positionInputRight);
		}

	}

	public void PositionChanging(bool inputRight){

		oldPosition = runner.transform.localPosition;
		Debug.Log (Vector3.Dot(runner.transform.forward, Vector3.forward));
		if(runner.rigidbody.velocity[0] == 10 || runner.rigidbody.velocity[0] == -10){
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
		
		if(!inputRight){
			runner.rigidbody.MovePosition(newPositionLeft);
			if(isRight){
				isRight = false;
			}else{
				isLeft = true;
			}

		}
		if(inputRight){
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
			Vector3 newSpeed = Vector3.Cross (ethan.speed,new Vector3(0,1,0));
			runner.transform.Rotate(Vector3.up, -90);
			ethan.speed = newSpeed;
			
		}else{
			Vector3 newSpeed = Vector3.Cross (new Vector3(0,1,0),ethan.speed);
			runner.transform.Rotate(Vector3.up, 90);
			ethan.speed = newSpeed;
		}

		if(runner.rigidbody.velocity[0] == 10 || runner.rigidbody.velocity[0] == -10){
			Vector3 temp = runner.transform.localPosition;
			temp.z = pM.nextPosition.z;
			runner.transform.localPosition = temp;
			isRight = false;
			isLeft = false;
		}else{
			Vector3 temp = runner.transform.localPosition;
			temp.x = pM.nextPosition.x;
			runner.transform.localPosition = temp;
			isRight = false;
			isLeft = false;
		}
	}
}
