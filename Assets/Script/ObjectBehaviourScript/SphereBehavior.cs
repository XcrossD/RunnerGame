using UnityEngine;
using System.Collections;

public class SphereBehavior : MonoBehaviour {

	void OnMouseDown()
	{
		rigidbody.AddForce(transform.forward * 500);
		rigidbody.useGravity = true; 
	}
	
}
