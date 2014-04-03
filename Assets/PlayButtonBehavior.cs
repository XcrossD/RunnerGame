using UnityEngine;
using System.Collections;

public class PlayButtonBehavior : MonoBehaviour {

	MouseControl mouseCon;
	public bool CursorEntered = false;


	// Use this for initialization
	void Start () {
		mouseCon =	gameObject.GetComponent<MouseControl>();
	}
	
	// Update is called once per frame
	void Update () {




	}
}
