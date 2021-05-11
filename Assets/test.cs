using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	
	float num = 0.0f;
	bool a = true;
	int phase = 0;
	float red = 0.0f;
	float green = 1.0f;
	float blue = 1.0f;

    // Update is called once per frame
    void Update()
    {
		if (num > 1.0f){
			a = false;
		}
		if (num < 0.03f){
			a = true;
		}
		
		if(a){
			num = num + 0.007f;
		}else{
			num = num - 0.007f;
		}
		
		if(phase == 0){
			blue = blue - 0.01f;
			if (blue <= 0.0f){
				phase = 1;
			}
		}else if(phase == 1){
			red = red + 0.01f;
			if (red >= 1.0f){
				phase = 2;
			}
		}else if(phase == 2){
			blue = blue + 0.01f;
			green = green - 0.01f;
			if (blue >= 1.0f){
				phase = 3;
			}
		}else if(phase == 3){
			red = red - 0.01f;
			green = green + 0.01f;
			if (green >= 1.0f){
				phase = 0;
			}
		}
		
		GetComponent<Renderer>().material.shader = Shader.Find("Custom/NewSurfaceShader");
		GetComponent<Renderer>().material.SetFloat("_ExtrusionFactor", num);
		
		GetComponent<Renderer>().material.SetFloat("_Red", red);
		GetComponent<Renderer>().material.SetFloat("_Blue", blue);
		GetComponent<Renderer>().material.SetFloat("_Green", green);
    }
}
