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
		//Debug.Log ("crosscut" + crossCutPanel.GetComponent<CrossCutModified>().on);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "GameController"){
			if(crossCutPanel.GetComponent<CrossCutModified>().on){
				rightFrontPanel.GetComponent<RightFrontPanelBehavior>().on = true;
				leftFrontPanel.GetComponent<LeftFrontPanelBehavior>().on = true;
				crossCutPanel.GetComponent<CrossCutModified>().on = false;
				GameObject.Destroy(gameObject, 0f);
			}else{
				rightFrontPanel.GetComponent<RightFrontPanelBehavior>().on = false;
				leftFrontPanel.GetComponent<LeftFrontPanelBehavior>().on = false;
				crossCutPanel.GetComponent<CrossCutModified>().on = true;
				GameObject.Destroy(gameObject, 0f);
			}
		}
	}

}
