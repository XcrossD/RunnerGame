using UnityEngine;
using System.Collections;

public class PunchCount : MonoBehaviour {

	public string leftPunchLevel = "-1";
	public string rightPunchLevel = "-1";
	private PunchControl punchscript;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		punchscript = GameObject.Find("Punch Control").GetComponent<PunchControl>();
		leftPunchLevel = punchscript.leftPunchLevel;
		rightPunchLevel = punchscript.rightPunchLevel;

		gameObject.guiText.text = "Left: "  +leftPunchLevel + "\n Right" + rightPunchLevel;
	}
}
