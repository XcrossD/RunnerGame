using UnityEngine;
using System.Collections;

public class GetCoin : MonoBehaviour {

	private CoinCount moneyCount;
	
	void Awake () {
	}
	
	void Start (){
	}
	
	//destroy the the coin when controller charater touched it
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "GameController"){
			Debug.Log(other.tag+"entered");
			
			other.GetComponent<CoinCount>().money ++;	
			GameObject.Destroy(gameObject, 0f);
		}
	}

}
