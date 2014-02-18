using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {
	public Texture2D originalCursor ;
	public bool showCursor = false;


	int cursorSizeX = Screen.width/8;  // set to width of your cursor texture
	int cursorSizeY = Screen.width/8;  // set to height of your cursor texture


	public int sensitivityX = 15;
	public int sensitivityY = 15;



	public class CursorPosition
	{
		public int x = Mathf.FloorToInt(Screen.width/2);   
		public int y = Mathf.FloorToInt(Screen.height/2);


	}
	
	public CursorPosition cursorpos = new CursorPosition();


	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			CursorShow();
		}




	}


	void OnGUI(){
		
		if (showCursor)
		{
			cursorpos.x += Mathf.FloorToInt(Input.GetAxis("Mouse X")*sensitivityX);
			cursorpos.x = Mathf.Clamp(cursorpos.x, 0, Screen.width);
			cursorpos.y -= Mathf.FloorToInt(Input.GetAxis("Mouse Y")*sensitivityY);
			cursorpos.y = Mathf.Clamp(cursorpos.y, 0, Screen.height);
			
			//-10 is the position of the cursor picture's point
			GUI.DrawTexture(new Rect(cursorpos.x -10, cursorpos.y -10, cursorSizeX, cursorSizeY),originalCursor);
			
			
		}

		
	}

	public void CursorShow()
	{

			if(showCursor)
			{
				showCursor =false;
				cursorpos.x = Mathf.FloorToInt(Screen.width/2);
				cursorpos.y = Mathf.FloorToInt(Screen.height/2);
			}
			else showCursor = true;

	}



}
