using UnityEngine;
using System.Collections;

public class TrunkBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.rigidbody.AddForce(Vector3.back * 700 * gameObject.rigidbody.mass);
	
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}
	
	
	void Rotate(){
		//gameObject.transform.Rotate(Vector3.up * Time.deltaTime );
		
	}
	
}
