using UnityEngine;
using System.Collections;

public class JillAnimate : MonoBehaviour {
	
	
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpPoseAnimation;
	
	private Animation animation;
	
	enum CharacterState {
	Idle = 0,
	Walking = 1,
	Trotting = 2,
	Running = 3,
	Jumping = 4,
	}
	
	private CharacterState characterState;
	
	
	// 
	void Awake(){
		animation = GetComponent<Animation>();
		if(!animation)
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
	
	
		if(!idleAnimation) {
			animation = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}	
	}
	
	
	
	
	
	
	void Start () {
		

		
		
	}
	
	private bool moving= false;
	
	// Update is called once per frame
	void Update () {
		
		moving = false;
		
		if (Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.S) ||Input.GetKey(KeyCode.D) ){
			moving =true;
		}	
		
		if(moving != true) {
			animation.CrossFade(idleAnimation.name);
		}
		else {
			animation.CrossFade(walkAnimation.name);	
			}
		}
	
}
