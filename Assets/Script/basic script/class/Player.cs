using UnityEngine;
using System.Collections;

public class Player{
	
	private int exp=0;
	private int money=0;
	private int life=100;
	private int maxlife=100;
	private int gem=0;
	
	//constuctor
	public Player(){		
	}
	
	//setting a special charater
	public Player(int maxlifepoint, int moneypoint){
		maxlife = maxlifepoint;
		money = moneypoint;	
		life = maxlife;		
	}
	
	
	//update maxlife when levelup
	public void LevelUp(){
		maxlife = Level * 100;
		life = maxlife;		
	}
	
	
    //Experience is a basic property
    public int Experience
    {
        get
        {
            //Some other code
            return exp;
        }
        set
        {
            //Some other code
            exp = value;
        }	
		
    }
    
    //Level is a property that converts experience
    //points into the level of a player automatically
	//Level is read only, so set is taken out
    public int Level
    {
        get
        {
            return exp / 100;
        }

    }
    
 
	//short hand example
    //public int Health{ get; set;}
	
	//This is an example of an auto-implemented
    //property
	public int Life{ 
		get
        {
            //Some other code
            return life;
        }
        set
        {
            //Some other code
            life = value;
        }

	}
	
	
	//money
	public int Money{ 
		get
        {
            //Some other code
            return money;
        }
        set
        {
            //Some other code
            money = value;
        }

	}
	
}