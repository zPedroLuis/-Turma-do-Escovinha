using UnityEngine;
using System.Collections;

public class barraDeVida : MonoBehaviour {

	private Animator animator1;


	// Use this for initialization
	void Start () 
	{
		animator1 = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (movimentoEscovinha.vidas == 0 )
		{
			animator1.SetInteger ("contadorVida", 1);
		}
		if (movimentoEscovinha.vidas == 1 )
		{
			animator1.SetInteger ("contadorVida", 2);
		}
		else if (movimentoEscovinha.vidas == 2 )
		{
			animator1.SetInteger ("contadorVida", 3);
		}
		else if (movimentoEscovinha.vidas == 3 )
		{
			animator1.SetInteger ("contadorVida", 4);
		}
		else if (movimentoEscovinha.vidas == 4 )
		{
			animator1.SetInteger ("contadorVida", 5);
		}
		else if (movimentoEscovinha.vidas == 5 )
		{
			animator1.SetInteger ("contadorVida", 6);
		}
		else if (movimentoEscovinha.vidas == 6 )
		{
			animator1.SetInteger ("contadorVida", 7);
		}
		else if (movimentoEscovinha.vidas == 7 )
		{
			animator1.SetInteger ("contadorVida", 8);
		}
		else if (movimentoEscovinha.vidas == 8 )
		{
			animator1.SetInteger ("contadorVida", 9);
		}
		else if (movimentoEscovinha.vidas == 9)
		{
			animator1.SetInteger ("contadorVida", 10);
		}
	}
}
