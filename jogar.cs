using UnityEngine;
using System.Collections;

public class jogar : MonoBehaviour 
{
	void Start () 
	{
	
	}	

	void Update () 
	{
		if (Input.GetKey("j"))
		{
			Application.LoadLevel("Nivel1");
			movimentoEscovinha.vidas = 9;
			Sujeira.pontuacao = 9;
		}
		if (Input.GetKey("t"))
		{
			Application.LoadLevel ("Nivel1");
			movimentoEscovinha.vidas = 9;
			Sujeira.pontuacao = 9;
		}
		if (Input.GetKey("v"))
		{
			Application.LoadLevel("menu");
		}
	/*	if (Input.GetKey("s"))
		{
			Application.LoadLevel("Sobre");
		}
		if (Input.GetKey("a"))
		{
			Application.LoadLevel("Ajuda");
		}
	*/
	}
}
