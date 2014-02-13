using UnityEngine;
using System.Collections;

public class ThirdPersoncamera : MonoBehaviour {
	
	private float distanceAway;
	private float distanceUp;
	private float smooth;
	private Transform follow;
	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		follow = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
