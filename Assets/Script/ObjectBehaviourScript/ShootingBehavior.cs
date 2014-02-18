using UnityEngine;
using System.Collections;

public class ShootingBehavior : MonoBehaviour {

	private CapsuleCollider myCollider;
	public float shootingspeed = 15f;
	public float max_radius = 1f;
	public bool reset = false;
	public float smoothing = 1f;
	private float radius_time = 0f;
	private float currentradius;
	private bool over_size = false;
	public bool reloading = false;
	
	
	void Start () {
		myCollider = transform.GetComponent<CapsuleCollider>();
		//enlarge the cylinder shape
		currentradius = myCollider.radius;	
	}
	
	void FixedUpdate () {
		
		CheckReset();
		
		//control enlarge or deminish the shot
		CheckOverSize();
		if (over_size)
		Deminish();
		else 
		Extend();
		
		//end of the shot and overshot
		CheckZeroShot();
		
		
	}
	
	
	//increase the size
	void Extend(){
		transform.localScale += new Vector3(Mathf.Lerp(currentradius, max_radius, radius_time)* Time.deltaTime *smoothing, shootingspeed * Time.deltaTime, Mathf.Lerp(currentradius, max_radius, radius_time)* Time.deltaTime) *smoothing;
		transform.Translate(Vector3.up * shootingspeed * Time.deltaTime);
		

		}
	
	//reducing the size
	void Deminish(){
		transform.localScale -= new Vector3(Mathf.Lerp(currentradius, max_radius, radius_time)* Time.deltaTime*smoothing, 0, Mathf.Lerp(currentradius, max_radius, radius_time)* Time.deltaTime*smoothing);
	}
	
	
	void CheckOverSize(){
		if (transform.localScale.x > max_radius){
			Debug.Log("oversized");
			over_size = true;
		}

	}
	
	
	void CheckReset(){
		if (reset){
			DoReset();
		}
	}
	
	
	//reset the position and size
	void DoReset(){
			Debug.Log("reseted");
			//start from min. size
			transform.localScale = new Vector3(0.3f, 1f, 0.3f);
		
			//start from original position
			transform.localPosition = new Vector3(0f,0f,0f);
			reset = false;
			over_size=false;
		}
	
	void CheckZeroShot(){
		if (transform.localScale.x < 0.1f){
			Debug.Log("reloading");
			reloading = true;
			gameObject.SetActive(false);
			
		}
		
	}
	
	
	
}
