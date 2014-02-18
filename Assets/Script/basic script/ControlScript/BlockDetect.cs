using UnityEngine;
using System.Collections;

public class BlockDetect : MonoBehaviour {
	
	public int blockhit= 0;
	public GameObject robot;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider block){

		if (block.tag == "Block"){
			blockhit ++;
			robot.rigidbody.AddForce( Vector3.up * 800 * robot.rigidbody.mass);
			
		}
	}
	
	
}
