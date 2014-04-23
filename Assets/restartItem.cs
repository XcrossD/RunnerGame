using UnityEngine;
using System.Collections;

public class restartItem : MonoBehaviour {
	
	private GameObject player;                      // Reference to the player.
	private PlayerInventory playerInventory;        // Reference to the player's inventory.
	
	private SceneFadeInOut gameoverscript;
	public GameObject fader;
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(Tags.gameController);
		playerInventory = player.GetComponent<PlayerInventory>();
		gameoverscript = fader.GetComponent<SceneFadeInOut>();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... play the clip at the position of the key...
			
			// ... the player has a key ...
			playerInventory.hasBook = true;
			
			// ... and destroy this gameobject.
			Destroy(gameObject);
			gameoverscript.EndScene();
			
		}
}
}
