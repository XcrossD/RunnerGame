using UnityEngine;
using System.Collections;

public class ButtonBehavior : MonoBehaviour {

	public bool showButtons = true; //same as started


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
	float ZminPos = 100;
	float ZcurrentPos =0;

	//plyabutton position
	float xPlayPos = 100;
	float yPlayPos = 100;
	float zdiff = 0;
	float enlargefactor = 1;


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
		buttonSizeX = Mathf.Min( Screen.width/3, Screen.height/3);
		xPlayPos = buttonSizeX/2*5;
		yPlayPos = buttonSizeX/2;
		enlargefactor = zdiff +1;

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
		if (XposCursor > xPlayPos && (XposCursor < (xPlayPos+buttonSizeX) ) )
			{
			if (YposCursor > yPlayPos && (YposCursor < (yPlayPos+buttonSizeX) ) )
				{
				//indicate the cursor is on play button
					onPlay=true;
					PressCheck();
				}
			}
		//disable the enlarge button behavior
		else 
		{
			onPlay=false;
			ZcurrentPos=0;
			ZminPos=100;
		}

		if (Input.GetKeyDown("'")){
			showButtons=true;
		}


	}




	//drawing the graphics like button
	void OnGUI(){

		if (showPlayButton == true){
			//draw the playbutton
			if (onPlay){
				GUI.DrawTexture(new Rect(xPlayPos, yPlayPos, buttonSizeX*enlargefactor, buttonSizeX*enlargefactor),playButton);
			}
			else 
				GUI.DrawTexture(new Rect(xPlayPos, yPlayPos, buttonSizeX, buttonSizeX),playButton);
		}

		if (showOptionButton == true){
			//draw the playbutton
			GUI.DrawTexture(new Rect(buttonSizeX/2, buttonSizeX/2*3, buttonSizeX, buttonSizeX),optionButton);
		}
			

		
		
	}

	//stop all the game objects to pause the game
	void StopAll(){
		//player.GetComponent<BasicMovementForEthan>().enabled=false;
		player.rigidbody.velocity= new Vector3(0,0,0);
		//player.GetComponent<Animator>().enabled=false;
		managers.SetActive(false);

	}


	//enable the game object to work
	void EnableAll(){

		//player.GetComponent<BasicMovementForEthan>().enabled=true;
		//player.GetComponent<Animator>().enabled=true;
		player.GetComponent<BasicMovementForEthan>().started=true;
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

	void PressCheck(){

		ZcurrentPos = cursorControlScript.Zpos;

		if (ZcurrentPos < ZminPos)
		{
			ZminPos = ZcurrentPos;
		}
		zdiff = ZcurrentPos-ZminPos;
		if (zdiff > 0.2f)
		{
			showButtons=false;
		}


	}

}
