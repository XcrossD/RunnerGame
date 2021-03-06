﻿using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
	
	public Transform prefab, trigger;
	public int numberOfObjects;
	public int recycleOffset;
	public Vector3 startPosition, nextPosition, platformSize, triggerSize, currentDirection, prevDirection, triggerPosition;
	public GameObject runner;
	public CoinManager coinManager;

	private float runnerObjectDistance;
	private Queue<Transform> objectQueue;
	public int turnLimit,turnCount;
	private Vector3[] Directions;
	
	// Use this for initialization
	void Start () {
		turnCount = 0;
		turnLimit = 1;
		currentDirection = Vector3.forward;
		prevDirection = currentDirection;
		startPosition = runner.transform.localPosition;
		startPosition.y -= 1f;
		Directions = new Vector3[] {currentDirection, Vector3.Cross(currentDirection, Vector3.up), Vector3.Cross(Vector3.up, currentDirection)};

		prefab.localScale = platformSize;
		trigger.localScale = triggerSize;

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
			currentDirection = Directions[Random.Range(0,3)];

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

			Transform t1 = (Transform)Instantiate(trigger);
			triggerPosition = nextPosition;
			t1.localPosition = triggerPosition - prevDirection * 5;
			Debug.Log("trigger1 instantiated");

			nextPosition += prevDirection * o.localScale.x/2;

			triggerPosition = nextPosition + currentDirection * o.localScale.x/2;
			Transform t2 = (Transform)Instantiate(trigger);
			t2.rotation = Quaternion.LookRotation(currentDirection);
			t2.localPosition = triggerPosition;
			Debug.Log("trigger2 instantiated");

			nextPosition += currentDirection * (o.localScale.z/2 - o.localScale.x/2);
			o.localPosition = nextPosition;
			coinManager.Spawn (o.localPosition);
			nextPosition += currentDirection * o.localScale.z;
			objectQueue.Enqueue(o);
		}else{
			o.localPosition = nextPosition;
			nextPosition += currentDirection * o.localScale.z;
			coinManager.Spawn (o.localPosition);
			objectQueue.Enqueue(o);
		}

	}
}
