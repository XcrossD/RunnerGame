using UnityEngine;
using System.Collections;

public class FlyingTrunks : MonoBehaviour {

	
	public GameObject block;
	public float xMaxRange = 4.0f;
	public float xMinRange = -4.0f;
	public float zMaxRange = 100.0f;
	public float zMinRange = 10.0f;
	
	void Start () {
		//keep repeating to create 
		InvokeRepeating ("EnergyPackage", 1, 3f);
	}
	
	
	void Update () {
		
	}
	
	void EnergyPackage(){
		float x = Random.Range(xMinRange, xMaxRange);
		float z = Random.Range(zMinRange, zMaxRange);
		//rotate the object
		
		//create a object with a time limit
		GameObject package = Instantiate(block, new Vector3(x, 5, z), Quaternion.identity) as GameObject;
		package.transform.localScale = new Vector3(1f, 15f, 1f);
		package.transform.Rotate(0,0,90);  //make the coin stand upward right
		Destroy(package, 10f);
		
	}
}
