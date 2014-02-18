using UnityEngine;
using System.Collections;

public class AutoChangeColor : MonoBehaviour {
	
	public float smooth = 3;
	private float timeout = 10f;
	private Color tran_red1 = new Color(255f, 0f, 0f, 0.2f);
	private Color tran_red2 = new Color(255f, 0f, 0f, 0.8f);
	private Color newcolor = new Color(255f, 0f, 0f, 0.2f);
	private const float color_const = 0.03f;
	
	void Start () {
		//initial the material color
		renderer.material.color = tran_red1 ;
		newcolor=renderer.material.color;
		
	}

	void Update () {
		//Auto Change its color between color 1 and 2
		SwitchColor(tran_red1, tran_red2);
	}
	
	//switching color between color A and B
	void SwitchColor(Color colorA, Color colorB){
		
		Color currentcolor = renderer.material.color;
		
		//do checking for finishing the color change and then keep looping
		if (ColorVeryClose(currentcolor.a, newcolor.a)){
			currentcolor = newcolor;
		}
		
		if (currentcolor.Equals(colorA)){
			newcolor=tran_red2;


		}
		if (currentcolor.Equals(colorB)){
			newcolor=tran_red1;
		}
		renderer.material.color = Color.Lerp(currentcolor , newcolor , smooth * Time.deltaTime);
	}
	
	
	
	//checking the color difference between the current and the destination color
	bool ColorVeryClose(float color1, float color2){
		float color_diff;
		
		color_diff = color1-color2;

		//only take positive value
		color_diff = Mathf.Abs(color_diff);
		if (color_diff < color_const)
			return(true);
		else 
			return(false);
		
	}
}
