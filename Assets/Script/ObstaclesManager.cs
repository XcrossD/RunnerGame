using UnityEngine;
using System.Collections;

public class ObstaclesManager : MonoBehaviour {

	public PlatformManager pM;
	public GameObject runner;
	public Transform ob1, ob2, ob3, ob4;
	public float time, timeTime;
	public Vector3 location;
	public Transform[] ob;

	// Use this for initialization
	void Start () {
		time = 0f;
		ob = new Transform[] {ob1, ob2, ob3, ob4};
	}
	
	// Update is called once per frame
	void Update () {
		timeTime = Time.time;
		if(Time.time > time && time != 0){
			appear ();
			time += Random.Range(3,8);
		}

	}

	private void appear(){
		location = runner.transform.localPosition;
		//location.y += 1.0f;

		location += pM.currentDirection * 25f;
		Transform o = (Transform)Instantiate(ob[Random.Range(0,4)]);
		o.transform.localPosition = location;
	}
}
