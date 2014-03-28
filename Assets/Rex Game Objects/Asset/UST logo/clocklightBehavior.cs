using UnityEngine;
using System.Collections;

public class clocklightBehavior : MonoBehaviour {
	
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;
	public GameObject five;
	public GameObject six;
	public GameObject seven;
	public GameObject eight;
	public GameObject nine;
	public GameObject ten;
	public GameObject eleven;
	public float RotateSpeed = 1000f;
	public float hour;

	// Use this for initialization
	void Start () {
		RotateSpeed = 10000f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hour +=  (1 *Time.deltaTime * RotateSpeed/60) ;
		hour= hour%360;

		if (hour>0 && hour<30){
			eleven.light.enabled= false;
			gameObject.light.enabled= true;
		}
		if (hour>30 && hour<60){
			gameObject.light.enabled= false;
			 one.light.enabled= true;
		}
		if (hour>60 && hour<90){
			one.light.enabled= false;
			two.light.enabled= true;
		}
		if (hour>90 && hour<120){
			two.light.enabled= false;
			three.light.enabled= true;
		}
		if (hour>120 && hour<150){
			three.light.enabled= false;
			four.light.enabled= true;
		}		
		if (hour>150 && hour<180){
			four.light.enabled= false;
			five.light.enabled= true;
		}
		if (hour>180 && hour<210){
			five.light.enabled= false;
			six.light.enabled= true;
		}		
		if (hour>210 && hour<240){
			six.light.enabled= false;
			seven.light.enabled= true;
		}
		if (hour>240 && hour<270){
			seven.light.enabled= false;
			eight.light.enabled= true;
		}		
		if (hour>270 && hour<300){
			eight.light.enabled= false;
			nine.light.enabled= true;
		}
		if (hour>300 && hour<330){
			nine.light.enabled= false;
			ten.light.enabled= true;
		}		
		if (hour>330 && hour<360){
			ten.light.enabled= false;
			eleven.light.enabled= true;
		}

}
}