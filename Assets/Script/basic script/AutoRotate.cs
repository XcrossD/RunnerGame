using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {
	
	
	public float RotateSpeed = 10f;
	
	// Use this for initialization
	void Start () {
		RotateSpeed = 100f;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		transform.Rotate(Vector3.forward * Time.deltaTime * RotateSpeed);
		
		
	}
		
	
	
}
