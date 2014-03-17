using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour {

	public PlatformManager platform;
	public Transform coin;
	public int numberOfObjects;

	private Vector3 nextPosition, currentDirection;
	private float seperateDistance;

	// Use this for initialization
	void Start (){
		seperateDistance = platform.platformSize.z/coin.transform.localScale.z;
		nextPosition = platform.startPosition;
		for(int i=0; i<numberOfObjects; i++){
			Transform o = (Transform)Instantiate(coin);
			o.transform.localPosition = nextPosition;
			nextPosition.z += seperateDistance;
		}
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void Spawn(Vector3 location){
		nextPosition = location;
		if(Vector3.Dot(platform.currentDirection, Vector3.right) == 0){
			nextPosition.z -= platform.platformSize.z/2 * platform.currentDirection.z;
			for(int i=0; i<numberOfObjects; i++){
				Transform o = (Transform)Instantiate(coin);
				o.transform.localPosition = nextPosition;
				nextPosition.z += seperateDistance * platform.currentDirection.z;
			}
		}else{
			nextPosition.x -= platform.platformSize.z/2 * platform.currentDirection.x;
			for(int i=0; i<numberOfObjects; i++){
				Transform o = (Transform)Instantiate(coin);
				o.transform.localPosition = nextPosition;
				nextPosition.x += seperateDistance * platform.currentDirection.x;
			}
		}

	}


}
