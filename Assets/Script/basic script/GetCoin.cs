using UnityEngine;
using System.Collections;

public class GetCoin : MonoBehaviour {

	//private CoinCount moneyCount;
	public CoinManager coinManager;
	
	void Awake () {
	}
	
	void Start (){
	}
	
	//destroy the the coin when controller charater touched it
	void OnCollisionEnter () {
		
		//if (other.tag == "GameController"){
			//Debug.Log(other.tag+"entered");
			
			//other.GetComponent<CoinCount>().money ++;	
		coinManager.Recycle();
		//}
	}

}
