using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {
	
	static int moneyCount =0;
	public GameObject user;
	
	
	// Use this for initialization
	void Start () {	
		ScoreChange();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreChange();
	
	}
	
	void ScoreChange(){
		moneyCount = user.GetComponent<CoinCount>().money*100;
		gameObject.guiText.text = "Score: "+moneyCount;
	}
	
}
