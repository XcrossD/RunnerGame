using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {



	// Use this for initialization
	void Start () {
		transform.localPosition = GameObject.Find("Relative position").transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
