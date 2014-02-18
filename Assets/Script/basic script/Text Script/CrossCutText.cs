using UnityEngine;
using System.Collections;

public class CrossCutText : MonoBehaviour 
{
	CrossCut crossCutScript;


	void Awake()
	{



	}


	void Update()
	{
		crossCutScript = GameObject.Find("Cross Cut Panel").GetComponent<CrossCut>();
		gameObject.guiText.text = "Cross Cut Count left: \n" + crossCutScript.leftCutCount +"Right: \n" + crossCutScript.rightCutCount;

	}

}
