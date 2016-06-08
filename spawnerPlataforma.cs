using UnityEngine;
using System.Collections;

public class spawnerPlataforma : MonoBehaviour 
{
	
	static Vector2 posicaoPlataforma;
	public GameObject plataformaMovimento;
	
	void Start () 
	{		
		posicaoPlataforma = transform.position;
		
		Instantiate (plataformaMovimento, posicaoPlataforma,transform.rotation);		
	}


	void Update () 
	{
		
	}
}
