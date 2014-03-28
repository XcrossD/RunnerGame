using UnityEngine;
using System.Collections;

public class TrunkBehavior : MonoBehaviour {


	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.


	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();

	}

	// Use this for initialization
	void Start () {
		//push the trunk to rotate 
		//gameObject.rigidbody.AddForce(Vector3.back * 700 * gameObject.rigidbody.mass);
		
	}
	
	// Update is called once per frame
	void Update () {
		Rotate();
	}
	
	
	void Rotate(){
		//gameObject.transform.Rotate(Vector3.up * Time.deltaTime );
		
	}

	void OnTriggerEnter(Collider others){
		// If the colliding gameobject is the player...
		if(others.gameObject.tag == "GameController")
		{
			hash = others.GetComponent<HashIDs>();
			anim = others.GetComponent<Animator>();
			//Killer the player
			anim.SetBool(hash.deadBool, true);

			//stop the game here

		}

	}
	void OnTriggerStay(Collider others){
		if(others.gameObject.tag == "GameController")
		{
			hash = others.GetComponent<HashIDs>();
			anim = others.GetComponent<Animator>();
			//Killer the player
			anim.SetBool(hash.deadBool, false);
			
			//stop the game here
			
		}



	}
	
}
