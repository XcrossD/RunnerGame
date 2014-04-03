using UnityEngine;
using System.Collections;

public class gameoverBehavior : MonoBehaviour {


	private Animator anim;       // Reference to the animator component.
	private HashIDs hash;  		// Reference to the HashIDs.
	private BasicMovementForEthan moveScript;
	public GameObject Manager;
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();  
		hash = GetComponent<HashIDs>();
		moveScript = GetComponent<BasicMovementForEthan>();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//stop the game
		if (anim.GetBool(hash.deadBool) == true){
			moveScript.enabled= false;
			rigidbody.velocity = new Vector3(0,0,0);

		}


	}
}
