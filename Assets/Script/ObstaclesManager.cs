using UnityEngine;
using System.Collections;

public class ObstaclesManager : MonoBehaviour {

	public PlatformManager pM;
	public GameObject runner;
	public Transform trunk;
	public float time, timeTime;
	public Vector3 location;

	// Use this for initialization
	void Start () {
		time = 0f;
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
		location.y += 5.0f;

		location += pM.currentDirection * 25f;
		Transform o = (Transform)Instantiate(trunk);
		o.transform.localPosition = location;
	}
}
