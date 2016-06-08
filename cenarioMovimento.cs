using UnityEngine;
using System.Collections;

public class cenarioMovimento : MonoBehaviour {

	float tempo = 0;
	float velocidadePlataforma;

	void Start () 
	{	
		tempo = 0;
		velocidadePlataforma = 8.0f;

	}

	void Update () 
	{		

		tempo += Time.deltaTime;
		if (tempo >= 0 && tempo < 2)	
		{
			transform.Translate(-Vector2.right * velocidadePlataforma * Time.deltaTime);
		}
		if (tempo >= 2 && tempo < 4)
		{
			transform.Translate(Vector2.right * velocidadePlataforma * Time.deltaTime);
		}
		if (tempo >= 4)
		{
			tempo = 0;
		}		
	}

}
