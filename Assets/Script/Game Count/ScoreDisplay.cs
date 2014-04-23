using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	public GameObject user;
	public int cash = 0;
	public int oldcoin = 0;
	
	// Use this for initialization
	void Start () {	
		ScoreChange();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreChange();
	
	}
	
	void ScoreChange(){

		CoinCount temp = user.GetComponent<CoinCount>();
		if (oldcoin != temp.money){

			if (temp.money < 0){
				cash += 100* temp.multiplier;


			}
			else cash += temp.money*100* temp.multiplier;
			
			gameObject.guiText.text = "Score: "+ cash;

			oldcoin = temp.money;

		}


	}
	
}
