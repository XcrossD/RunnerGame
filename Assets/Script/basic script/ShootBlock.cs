using UnityEngine;
using System.Collections;

public class ShootBlock : MonoBehaviour {
	
	
	
	public int shotPower = 1000000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider block){
		if (block.tag == "Block"){
			Debug.Log("add force");
			block.rigidbody.AddForce(Vector3.up * shotPower * block.rigidbody.mass );
			
			
		}
		
	}
	
}
