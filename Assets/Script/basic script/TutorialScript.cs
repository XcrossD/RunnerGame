using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	
	private string[] sentense = new string[100];
	//List<string> sentense = new List<string>();
	
	//change the tutCount can show next tutorial sentense
	public int tutCount=0;
	
	
	public int maxKinectTutCount = 0;
	public int maxTutCount = 0;
	public int minTutCount = 21;
	
	
	// Use this for initialization
	void Start () { 
		//sentense.Add(new string("Tutorial begins here, press \"t\" to continue"));
		//sentense.Add(new string("tutorial second line"));
		//sentense.Add(new string("tutorial 3rd line"));
		//sentense.Add(new Tutorial(""));
		
		//use array to save the tutorial lines
		sentense[0] = "Tutorial begins here, press \"t\" to continue";
		sentense[1] = "press Y to see the prvious tutorial, or press k to see Kinect control tutorial";
		sentense[2] = "press wasd keys can control the move";
		sentense[3] = "press shift to move in sneak mode";
		sentense[4] = "Sneak under trunk can avoid hurt";
		sentense[5] = "Reach the end of the way can win the game";
		sentense[6] = "Enjoy~";
		//sentense[22] = "Open your hands to your chest level";
		//sentense[23] = "Move right hand forward can move the robot to the right and forward";
		//sentense[24] = "Move your left hand forward can move the robot to the left and forward";
		//sentense[25] = "Move both of your hand forward can go straight";
		//sentense[26] = "Move your both hands backward can move backward";
		//sentense[27] = "Move one of your hand to above your head can jump";
		maxTutCount = 6+1;
		maxKinectTutCount = 22+1;
		
		//sentense[] = "";
		//maxTutCount = sentense.Length;
		DisplayText();
		
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
	}
	
	void GetInput(){
		if (Input.GetKeyDown(KeyCode.T)){
			NextSent(); 			
		}
		if (Input.GetKeyDown(KeyCode.Y)){
			PreviousSent(); 			
		}
		
		
	}
	
	void NextSent(){
		
		//check for the last line of tutorial
		if (tutCount < maxTutCount -1){
		tutCount++;
		
		DisplayText();
		}
		
	}
	
	void PreviousSent(){
		//check for the first line of tutorial
		if (tutCount > 0){
		tutCount --;
		
		DisplayText();
		}
		
	}
	
	
	void DisplayText(){
		gameObject.guiText.text = sentense[tutCount];
			
	}
	
	
	//create a class of tutorial lines
	public class Tutorial{
		string tutorSentense;
		
	}
	
}
