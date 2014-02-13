using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	public int recycleOffset, minSize, maxSize;
	public Vector3 startPosition;
	public GameObject runner;
	public float runnerObjectDistance;
	
	private Vector3 nextPosition, currentDirection;
	private Queue<Transform> objectQueue;
	private int initLimit,frameCountDeduction;
	private Vector3[] Directions = new Vector3[] {new Vector3(1f,0f,0f), new Vector3(0f,0f,1f), new Vector3(0f,0f,-1f)};
	
	
	// Use this for initialization
	void Start () {
		initLimit = 3;
		frameCountDeduction = 0;
		currentDirection = Directions[0];
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
		if (runnerObjectDistance > recycleOffset) {
			Recycle();
		}
	}
	
	private void Recycle () {
		if(Time.frameCount/100 - frameCountDeduction < initLimit){
			Transform o = objectQueue.Dequeue();
			o.localPosition = nextPosition;
			nextPosition += currentDirection;
			objectQueue.Enqueue(o);
		}else{
			Transform o = objectQueue.Dequeue();
			o.localPosition = nextPosition;
			currentDirection = Directions[Random.Range(0,2)];
			nextPosition += currentDirection;
			objectQueue.Enqueue(o);
			frameCountDeduction += initLimit;
			initLimit = Random.Range(minSize,maxSize);
		}
	}
}
