using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	public Texture2D playButton;
	public bool showPlayButton = true;

	public Texture2D optionButton;
	public bool showOptionButton = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}





	void OnGUI(){
		
		if (showPlayButton == true){
			//draw the playbutton
			GUI.DrawTexture(new Rect(50, 50, 100, 100),playButton);
		}

		if (showOptionButton == true){
			//draw the playbutton
			GUI.DrawTexture(new Rect(50, 300, 100, 100),optionButton);
		}
			

		
		
	}

}
