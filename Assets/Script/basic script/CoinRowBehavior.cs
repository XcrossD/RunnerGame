using UnityEngine;
using System.Collections;

public class CoinRowBehavior : MonoBehaviour {
	
	public float timeout = 60f;
	
	
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, timeout);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
