using UnityEngine;
using System.Collections;

public class mainbodyRotate : MonoBehaviour {
	public float RotateSpeed = 1000f;

	// Use this for initialization
	void Start () {
		RotateSpeed = 10000f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed/60);
	}
}
