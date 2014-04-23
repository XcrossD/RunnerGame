using UnityEngine;
using System.Collections;

public class ethanDieGameRestart : MonoBehaviour {

	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;  				// Reference to the HashIDs.


	public GameObject fader;  //fader to restart the game


	void Awake(){
		anim = GetComponent<Animator>();
		hash = GetComponent<HashIDs>();
	}



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		bool temp = anim.GetBool(hash.deadBool);
		if (temp){
			fader.GetComponent<SceneFadeInOut>().resetTime = 4;
			fader.GetComponent<SceneFadeInOut>().EndScene();


		} 
	}
}
