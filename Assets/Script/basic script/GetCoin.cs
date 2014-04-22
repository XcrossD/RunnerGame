using UnityEngine;
using System.Collections;

public class GetCoin : MonoBehaviour {

	public GameObject runner, pM;
	public PlatformManager pMScript;

	private CoinCount moneyCount;
	private float runnerObjectDistance;
	
	void Awake () {
	}
	
	void Start (){
		runner = GameObject.Find("char_ethan modified");
		pM = GameObject.Find("PlatformManager");
		pMScript = pM.GetComponent<PlatformManager>();
	}

	void Update (){
		Destroy();
	}
	
	//destroy the the coin when controller charater touched it
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "GameController"){
			Debug.Log(other.name+" entered");
			
			other.GetComponent<CoinCount>().money ++;	
			GameObject.Destroy(gameObject, 0f);
		}
	}

	public void Destroy (){
		if(pMScript.currentDirection[0] == 0){
			runnerObjectDistance = (runner.transform.localPosition.z - transform.localPosition.z) * pMScript.currentDirection[2];
			if(runnerObjectDistance > 10f){
				GameObject.Destroy(gameObject, 0f);
			}
		}else{
			runnerObjectDistance = (runner.transform.localPosition.x - transform.localPosition.x) * pMScript.currentDirection[0];
			if(runnerObjectDistance > 10f){
				GameObject.Destroy(gameObject, 0f);
			}
		}
	}

}
