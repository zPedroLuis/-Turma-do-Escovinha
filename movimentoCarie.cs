using UnityEngine;
using System.Collections;

public class movimentoCarie : MonoBehaviour {
	float tempo = 0;
	float velocidade;
	// Use this for initialization
	void Start () 
	{	
		tempo = 0;
		velocidade = 2.0f;
	}

	// Update is called once per frame
	void Update () 
	{		
		tempo += Time.deltaTime;
		if (tempo >= 0 && tempo < 3)	
		{
			transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
		}
		if (tempo >= 3 && tempo < 6)
		{
			transform.Translate(Vector2.right * velocidade * Time.deltaTime);
		}
		if (tempo >= 6)
		{
			tempo = 0;
		}

	}
}
