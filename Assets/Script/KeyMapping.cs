using UnityEngine;
using System.Collections;

public class KeyMapping : MonoBehaviour {

	public GameObject runner;
	//public PlatformManager pM;
	public Vector3 newPositionLeft, newPositionRight, oldPosition, newPosition;
	public bool isRight, isLeft;

	// Use this for initialization
	void Start () {
		isRight = false;
		isLeft = false;
	}
	
	// Update is called once per frame
	void Update () {
		PositionChanging();

	}

	void PositionChanging(){

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
		
		if(Input.GetKeyDown(KeyCode.Q)){
			runner.rigidbody.MovePosition(newPositionLeft);
			if(isRight){
				isRight = false;
			}else{
				isLeft = true;
			}

		}
		if(Input.GetKeyDown(KeyCode.E)){
			runner.rigidbody.MovePosition(newPositionRight);
			if(isLeft){
				isLeft = false;
			}else{
				isRight = true;
			}
		}
	}
}
