using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
	public float jumpforce = 300f;
	public bool isjumping = false;
    public bool shortjumping = false;
	public bool longjumping = false;
    
	
	//it support double jump
	//press space twice can have high jump;
	
	
	void Start(){
		//initial the jump height
		jumpforce = jumpforce * gameObject.rigidbody.mass;
	}
	
	
	
    void Update ()
    {
		
		
		
		//moving
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		
		//jump
		LandedCheck();
		LongJump();   //double jump so long jump is before spaceJump
		SpaceJump();
		
		

    }
	
	//checking whether the object in on the ground
	void LandedCheck(){
		if (gameObject.transform.localPosition.y < 1){
			isjumping = false;
			shortjumping = false;
			longjumping = false;
		}
	}
	
	
	//check space is pressed
	void SpaceJump(){
		if (Input.GetKeyDown(KeyCode.Space)){
			Jump();	
		}
	}
	
	
	
	
	//avoid jumpping in the air
	void Jump(){
		if (!isjumping){
			DoJump();
			shortjumping = true;
		}
	}
	
	//normal jump from ground
	void DoJump(){
		gameObject.rigidbody.AddForce(Vector3.up * jumpforce); 
		Debug.Log("The robot jumped");
		isjumping = true;
	}
	
	//Second jump
	void LongJump(){
		if (shortjumping && Input.GetKeyDown(KeyCode.Space) && !longjumping){
			longjumping =true;
			DoJump();
		}
		
		
	}
	
}