using UnityEngine;
using System.Collections;

public class fixedObstacle : MonoBehaviour {

	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.
	

	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter(Collider others){
		// If the colliding gameobject is the player...
		if(others.gameObject.tag == "GameController")
		{
			hash = others.GetComponent<HashIDs>();
			anim = others.GetComponent<Animator>();
			
			//check jump
			if (anim.GetBool(hash.jumpBool)==false)
			{
				//Killer the player
				anim.SetBool(hash.deadBool, true);
				Invoke("Kill", 0.2f);
			}
		}
		
	}
	
	void Kill(){
		//kill the player without repeating the dead bool checked
		anim.SetBool(hash.deadBool, false);
		
		
	}
}
