using UnityEngine;
using System.Collections;

public class RandomBlocks : MonoBehaviour {

	public GameObject block;
	public float xMaxRange = 30.0f;
	public float xMinRange = -30.0f;
	public float zMaxRange = 38.0f;
	public float zMinRange = 36.0f;

	void Start () {
		//keep repeating to create 
		InvokeRepeating ("EnergyPackage", 1, 1);
	}
	

	void Update () {
	
	}
	
	void EnergyPackage(){
		float x = Random.Range(xMinRange, xMaxRange);
        float z = Random.Range(zMinRange, zMaxRange);
		//rotate the object

		//create a object with a time limit
		GameObject package = Instantiate(block, new Vector3(x, 3, z), Quaternion.identity) as GameObject;
		package.transform.Rotate(0,0,90);  //make the coin stand upward right
		Destroy(package, 20f);
		
	}
}
