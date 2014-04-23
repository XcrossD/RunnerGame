using UnityEngine;
using System.Collections;

public class platformTrigger : MonoBehaviour {

	private HashIDs hash; 
	private GameObject rightFrontPanel, leftFrontPanel, crossCutPanel;


	// Use this for initialization
	void Start () {
		rightFrontPanel = GameObject.Find("Right Front Panel");
		leftFrontPanel = GameObject.Find ("Left Front Panel");
		crossCutPanel = GameObject.Find ("Cross Cut Panel");
		crossCutPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		Debug.Log ("ethan collided");
		if(rightFrontPanel.activeSelf){
			rightFrontPanel.SetActive(true);
			leftFrontPanel.SetActive(true);
			crossCutPanel.SetActive(false);
			GameObject.Destroy(gameObject, 0f);
		}else{
			rightFrontPanel.SetActive(false);
			leftFrontPanel.SetActive(false);
			crossCutPanel.SetActive(true);
			GameObject.Destroy(gameObject, 0f);
		}

	}

}
