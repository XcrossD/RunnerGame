using UnityEngine;
using System.Collections;

public class KeyMapping : MonoBehaviour {

	public GameObject runner;
	public PlatformManager pM;
	public Vector3 newPositionLeft, newPositionRight, oldPosition, newPosition;
	public float turnPosition;
	public bool isRight, isLeft, turnToZ;

	// Use this for initialization
	void Start () {
		isRight = false;
		isLeft = false;
	}
	
	// Update is called once per frame
	void Update () {
		//PositionChanging();
		//RotationChanging();

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
		if(Vector3.Dot(runner.transform.forward, Vector3.forward) == 0){
			turnPosition = pM.nextPosition.z;
			turnToZ = true;
			if(isLeft){
				turnPosition += Vector3.Cross(Vector3.up,pM.currentDirection).x * 2.5f;
			}else{
				turnPosition -= Vector3.Cross(Vector3.up,pM.currentDirection).x * 2.5f;
			}
		}else{
			turnPosition = pM.nextPosition.x;
			turnToZ = false;
			if(isLeft){
				turnPosition += Vector3.Cross(Vector3.up,pM.currentDirection).z * 2.5f;
			}else{
				turnPosition -= Vector3.Cross(Vector3.up,pM.currentDirection).z * 2.5f;
			}
		}

		if(!inputRight){
			if(turnToZ){
				if(runner.transform.localPosition.z == turnPosition){
					runner.transform.Rotate(Vector3.up, -90);
				}
			}else{
				if(runner.transform.localPosition.x == turnPosition){
					runner.transform.Rotate(Vector3.up, -90);
				}
			}
		}

		if(inputRight){
			if(turnToZ){
				if(runner.transform.localPosition.z == turnPosition){
					runner.transform.Rotate(Vector3.up, 90);
				}
			}else{
				if(runner.transform.localPosition.x == turnPosition){
					runner.transform.Rotate(Vector3.up, 90);
				}
			}
		}
	}
}
