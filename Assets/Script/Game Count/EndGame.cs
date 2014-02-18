using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	private SceneFadeInOut sceneFadeInOut;// Reference to the SceneFadeInOut script.
	private GameObject player;
	//private Tags tags;

	// Use this for initialization
	void Start () {
		sceneFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<SceneFadeInOut>();
		player = GameObject.Find("char_ethan modified");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){

		if (other.tag == player.tag)
		{
		sceneFadeInOut.EndScene();

		}
	}

}
