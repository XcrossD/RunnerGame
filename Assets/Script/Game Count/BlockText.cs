using UnityEngine;
using System.Collections;

public class BlockText : MonoBehaviour {

	static int BlockCount =0;
	public GameObject userDetector;
	
	
	// Use this for initialization
	void Start () {	
		ScoreChange();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreChange();
	
	}
	
	void ScoreChange(){
		BlockCount = userDetector.GetComponent<BlockDetect>().blockhit;
		gameObject.guiText.text = "Damage: "+BlockCount * 20;
	}
	
}