using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	public int recycleOffset;
	public Vector3 startPosition, nextPosition, platformSize, currentDirection;
	public GameObject runner;

	private float runnerObjectDistance;
	private Vector3 prevDirection;
	private Queue<Transform> objectQueue;
	private int turnLimit,turnCount;
	private Vector3[] Directions;
	
	// Use this for initialization
	void Awake () {
		turnCount = 0;
		turnLimit = 3;
		currentDirection = Vector3.forward;
		prevDirection = currentDirection;
		Directions = new Vector3[] {currentDirection, Vector3.Cross(currentDirection, Vector3.up), Vector3.Cross(Vector3.up, currentDirection)};

		prefab.localScale = platformSize;

		objectQueue = new Queue<Transform>(numberOfObjects);
		
		for(int i=0; i<numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}
		nextPosition = startPosition;
		for(int i=0; i<numberOfObjects; i++){
			Recycle();
		}
	}
	
	// Update is called once per frame
	void Update () {
		runnerObjectDistance = (runner.transform.localPosition - objectQueue.Peek().localPosition).magnitude;

		if(turnCount == turnLimit){

			prevDirection = currentDirection;
			currentDirection = Directions[Random.Range(0,2)];

			if(prevDirection != currentDirection){
				Directions = new Vector3[] {currentDirection, Vector3.Cross(currentDirection, Vector3.up), Vector3.Cross(Vector3.up, currentDirection)};
			}

			turnCount = 0;
			turnLimit = Random.Range(3,5);
		}

		if (runnerObjectDistance > recycleOffset) {
			Recycle();
			turnCount++;
		}
	}
	
	private void Recycle () {
			
		Transform o = objectQueue.Dequeue();
		o.rotation = Quaternion.LookRotation(currentDirection);

		if(prevDirection != currentDirection && turnCount == 0){
			nextPosition -= prevDirection * o.localScale.z/2;
			nextPosition += prevDirection * o.localScale.x/2;
			nextPosition += currentDirection * (o.localScale.z/2 - o.localScale.x/2);
			o.localPosition = nextPosition;
			nextPosition += currentDirection * o.localScale.z;
			objectQueue.Enqueue(o);
		}else{
			o.localPosition = nextPosition;
			nextPosition += currentDirection * o.localScale.z;
			objectQueue.Enqueue(o);
		}

	}
}
