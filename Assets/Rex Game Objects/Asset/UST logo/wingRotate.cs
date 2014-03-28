using UnityEngine;
using System.Collections;

public class wingRotate : MonoBehaviour {

	public float RotateSpeed = 600f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * RotateSpeed);
	}
}
