using UnityEngine;
using System.Collections.Generic;

public class CoinManager : MonoBehaviour {

	public Transform coin;
	public int numberOfObjects, recycleOffset;
	public Vector3 startPosition;
	public GameObject runner;
	public PlatformManager platform;

	private Queue<Transform> objectQueue;
	private Vector3 nextPosition, currentDirection;
	private float runnerObjectDistance;

	// Use this for initialization
	void Start () {

		startPosition = new Vector3(0,0,20);
		currentDirection = Vector3.forward;
		objectQueue = new Queue<Transform>(numberOfObjects);
		
		for(int i=0; i<numberOfObjects; i++){
			objectQueue.Enqueue((Transform)Instantiate(coin));
		}
		nextPosition = startPosition;
		for(int i=0; i<numberOfObjects; i++){
			Recycle();
		}
	}
	
	// Update is called once per frame
	void Update () {

		runnerObjectDistance = (runner.transform.localPosition - objectQueue.Peek().localPosition).magnitude;

		if (runnerObjectDistance > recycleOffset) {
			Recycle();
		}
	}

	public void Recycle () {

		currentDirection = platform.currentDirection;
		Transform o = objectQueue.Dequeue();
		o.localPosition = nextPosition;
		nextPosition += currentDirection * o.localScale.z * 3;
		objectQueue.Enqueue(o);
		
	}
}
