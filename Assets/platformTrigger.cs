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
		crossCutPanel.GetComponent<CrossCutModified>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){

		if(crossCutPanel.GetComponent<CrossCutModified>().enabled){
			rightFrontPanel.GetComponent<RightFrontPanelBehavior>().enabled = true;
			leftFrontPanel.GetComponent<LeftFrontPanelBehavior>().enabled = true;
			crossCutPanel.GetComponent<CrossCutModified>().enabled = false;
			GameObject.Destroy(gameObject, 0f);
		}else{
			rightFrontPanel.GetComponent<RightFrontPanelBehavior>().enabled = false;
			leftFrontPanel.GetComponent<LeftFrontPanelBehavior>().enabled = false;
			crossCutPanel.GetComponent<CrossCutModified>().enabled = true;
			GameObject.Destroy(gameObject, 0f);
		}

	}

}
