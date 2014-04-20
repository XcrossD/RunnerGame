using UnityEngine;
using System.Collections;

public class BasicMovementForEthan : MonoBehaviour
{
	
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter

	public bool started = false;

	public Vector3 speed;
	public KeyMapping kM;
	public ObstaclesManager oM;
	
	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.
	//private bool touchingPlatform;
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		hash = GetComponent<HashIDs>();
		
		// Set the weight of the shouting layer to 1.
		//anim.SetLayerWeight(1, 1f);
		speed = new Vector3(0,0,10);
	}
	
	
	void FixedUpdate ()
	{
		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool sneak = Input.GetButton("Sneak");
		
		MovementManagement(h, v, sneak);
	}
	bool keyboardstart = false;
	
	void Update ()
	{

		//Move Ethan
		rigidbody.velocity = new Vector3(0,0,0);

		if (started || (Input.GetKeyDown("9")) || keyboardstart){
			if(!keyboardstart){
				oM.time = Time.time + 5f;
			}
			keyboardstart=true;
			Debug.Log ("started");
			anim.SetFloat(hash.speedFloat, 5.5f);
			rigidbody.velocity = speed;
		}

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
		/*
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
*/

		//perform jump and the animation
		if (Input.GetButton("Jump") == true)
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