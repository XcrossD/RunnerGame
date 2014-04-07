using UnityEngine;
using System.Collections;

public class RightFrontPanelBehavior : MonoBehaviour {
	
	public Collider rightHandCollider;
	public Collider leftHandCollider;
	public GameObject robot;
	public KeyMapping kM;
	private float moveSpeed =5f;
	
	// Use this for initialization
	void Start () {
		//Debug.Log("right front panel is ready");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//command from the hand detection
	void OnTriggerEnter(Collider handCollider){
		if (handCollider.name == rightHandCollider.name){
			//Debug.Log("right hand is detected is detect in right hand panel");
			//robot.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
			//robot.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			kM.PositionChanging(true);
		}
		
		if (handCollider.name == leftHandCollider.name){
			//Debug.Log("left hand is detected is detect in right hand panel");
		}
		
		
		
		
	}
}
