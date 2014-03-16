﻿using UnityEngine;
using System.Collections;

public class BasicMovementForEthan : MonoBehaviour
{
	
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	
	
	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.
	//private bool touchingPlatform;
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		
		// Set the weight of the shouting layer to 1.
		//anim.SetLayerWeight(1, 1f);
	}
	
	
	void FixedUpdate ()
	{
		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool sneak = Input.GetButton("Sneak");
		
		MovementManagement(h, v, sneak);
	}
	
	
	void Update ()
	{
		//Move Ethan
		transform.Translate(0f, 0f, 10f * Time.deltaTime);

		// Set the animator shouting parameter.
		//anim.SetBool(hash.shoutingBool, Input.GetButtonDown("Attract"));

		/*
		//lower the body
		if (Input.GetKey(KeyCode.LeftShift))
		{
			gameObject.transform.GetComponent<CapsuleCollider>().height =1.3f;
		}
		else gameObject.transform.GetComponent<CapsuleCollider>().height =2f;
		*/
	}

	
	void MovementManagement (float horizontal, float vertical, bool sneaking)
	{
		// Set the sneaking parameter to the sneak input.
		//anim.SetBool(hash.sneakingBool, sneaking);
		
		// If there is some axis input...
		if(horizontal != 0f || vertical != 0f)
		{
			// ... set the players rotation and set the speed parameter to 5.5f.
			Rotating(horizontal, vertical);
			anim.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
		}
		else
			// Otherwise set the speed parameter to 0.
			anim.SetFloat(hash.speedFloat, 0);

		//perform jump and the animation
		if (Input.GetButtonDown("Jump"))
		{
			anim.SetBool(hash.jumpBool, true);
		}
		else anim.SetBool(hash.jumpBool, false);



	}
	
	
	void Rotating (float horizontal, float vertical)
	{
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
	}
	
}