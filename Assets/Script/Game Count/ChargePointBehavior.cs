using UnityEngine;
using System.Collections;

public class ChargePointBehavior : MonoBehaviour {
	
	public GameObject energyPack;
	public float xMaxRange = 10.0f;
	public float xMinRange = -10.0f;
	public float yMaxRange = 10.0f;
	public float yMinRange = -10.0f;
	
	


	void Start () {
		//keep repeating to create 
		InvokeRepeating ("EnergyPackage", 1, 1);
		
	}
	

	void Update () {
	
	}
	
	void EnergyPackage(){
		float x = Random.Range(xMinRange, xMaxRange);
        float z = Random.Range(yMinRange, yMaxRange);
		//rotate the object

		//create a object with a time limit
		GameObject package = Instantiate(energyPack, new Vector3(x, 3, z), Quaternion.identity) as GameObject;
		package.transform.Rotate(90,0,0);  //make the coin stand upward right
		Destroy(package, 10f);
		
	}
	
}
