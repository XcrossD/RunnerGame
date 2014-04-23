using UnityEngine;
using System.Collections;

public class CoinCount : MonoBehaviour {
	public int money = 0;
	public int multiplier = 1;


	PlayerInventory inventory;

	
	// Use this for initialization
	void Start () {
		inventory = GetComponent<PlayerInventory>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inventory.hasLaptop){
			multiplier = 10;
		}
	}
}
