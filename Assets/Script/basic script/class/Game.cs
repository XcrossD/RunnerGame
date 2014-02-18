using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	
	public int exp;
    void Start () 
    {
        Player myPlayer = new Player();
        
        //Properties can be used just like variables
		//add experience to player class
        myPlayer.Experience += 5;
		//put the experience in to exp variable
        exp = myPlayer.Experience;
    }
}