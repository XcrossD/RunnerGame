using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	public bool showButtons = true;


	public Texture2D playButton;
	public bool showPlayButton = true;

	public Texture2D optionButton;
	public bool showOptionButton = true;
	public bool onPlay = false;

	int buttonSizeX = Mathf.Min( Screen.width/4, Screen.height/4);  // set to width of your cursor texture



	//button
	public GameObject cursorPanel;
	CursorControl cursorControlScript;
	MouseControl mouseControlScript;
	int XposCursor = 0;
	int YposCursor = 0;


	//game objects
	public GameObject player;
	public GameObject managers;


	// Use this for initialization
	void Start () {
		cursorControlScript = cursorPanel.GetComponent<CursorControl>();
		mouseControlScript = cursorPanel.GetComponent<MouseControl>();
	}
	
	// Update is called once per frame
	void Update () {

		//button initialize
		buttonSizeX = Mathf.Min( Screen.width/4, Screen.height/4);

		//stop things before start button is pressed
		if (showButtons)
		{
			//stop all the thing before game start
			ShowButtons();
			StopAll();
		}
		else 
		{
			//enable the gameplay
			EnableAll();
			hideButtons();
		}


		//check whether the cursor in entering the button play
		XposCursor=cursorControlScript.cursorX;
		YposCursor=cursorControlScript.cursorY;
		if (XposCursor > buttonSizeX/2 && (XposCursor < (buttonSizeX/2+buttonSizeX) ) )
			{
			if (YposCursor > buttonSizeX/2 && (YposCursor < (buttonSizeX/2+buttonSizeX) ) )
				{
				//indicate the cursor is on play button
					onPlay=true;
					EnableAll();
					showButtons=false;
				}
			}
		//disable the enlarge button behavior
		else onPlay=false;




	}




	//drawing the graphics like button
	void OnGUI(){

		if (showPlayButton == true){
			//draw the playbutton
			if (onPlay){
				GUI.DrawTexture(new Rect(buttonSizeX/2, buttonSizeX/2, buttonSizeX*1.3f, buttonSizeX*1.3f),playButton);
			}
			else 
			GUI.DrawTexture(new Rect(buttonSizeX/2, buttonSizeX/2, buttonSizeX, buttonSizeX),playButton);
		}

		if (showOptionButton == true){
			//draw the playbutton
			GUI.DrawTexture(new Rect(buttonSizeX/2, buttonSizeX/2*3, buttonSizeX, buttonSizeX),optionButton);
		}
			

		
		
	}

	//stop all the game objects to pause the game
	void StopAll(){
		player.GetComponent<BasicMovementForEthan>().enabled=false;
		player.GetComponent<Animator>().enabled=false;
		managers.SetActive(false);
	}


	//enable the game object to work
	void EnableAll(){

		player.GetComponent<BasicMovementForEthan>().enabled=true;
		player.GetComponent<Animator>().enabled=true;
		managers.SetActive(true);

	}

	//show all the buttons and cursor
	void ShowButtons()
	{
		showButtons=true;
		showPlayButton=true;
		showOptionButton=true;
		mouseControlScript.enabled=true;

	}

	//disable all the buttons and cursor
	void hideButtons(){
		showButtons=false;
		showOptionButton=false;
		showPlayButton=false;
		mouseControlScript.enabled=false;

	}

}
