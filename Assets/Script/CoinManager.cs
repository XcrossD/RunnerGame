using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour {

	public PlatformManager platform;
	public Transform coin;
	public int numberOfObjects;

	private Vector3 nextPosition;
	private float vectorTest;
	private float[] lanes = new float[]{-2.5f, 0f, 2.5f};

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update () {



	}

	public void Spawn(Vector3 location){
		nextPosition = location;
		nextPosition.y += 2f;
		vectorTest = Vector3.Dot(platform.currentDirection, Vector3.right);
		if(vectorTest == 0){
			nextPosition.z -= platform.platformSize.z/2 * platform.currentDirection.z;
			nextPosition.x += lanes[Random.Range (0,3)];
			if(platform.prevDirection != platform.currentDirection){
				nextPosition.z += 10 * platform.currentDirection.z;
				for(int i=1; i<numberOfObjects; i++){
					Transform o = (Transform)Instantiate(coin);
					o.transform.localPosition = nextPosition;
					nextPosition.z += 10 * platform.currentDirection.z;
				}
			}else{
				for(int i=0; i<numberOfObjects; i++){
					Transform o = (Transform)Instantiate(coin);
					o.transform.localPosition = nextPosition;
					nextPosition.z += 10 * platform.currentDirection.z;
				}
			}
		}else{
			nextPosition.x -= platform.platformSize.z/2 * platform.currentDirection.x;
			nextPosition.z += lanes[Random.Range (0,3)];
			if(platform.prevDirection != platform.currentDirection){
				nextPosition.x += 10 * platform.currentDirection.x;
				for(int i=1; i<numberOfObjects; i++){
					Transform o = (Transform)Instantiate(coin);
					o.transform.localPosition = nextPosition;
					nextPosition.x += 10 * platform.currentDirection.x;
				}
			}else{
				for(int i=0; i<numberOfObjects; i++){
					Transform o = (Transform)Instantiate(coin);
					o.transform.localPosition = nextPosition;
					nextPosition.x += 10 * platform.currentDirection.x;
				}
			}
		}

	}


}
