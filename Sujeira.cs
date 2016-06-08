using UnityEngine;
using System.Collections;

public class Sujeira : MonoBehaviour 
{

	private Animator animator1;
	public static int pontuacao = 9;


	void Start () 
	{
		pontuacao = 9;
		animator1 = this.GetComponent<Animator>();
	}

	void Update () 
	{

		//Executa as translaçoes de sprites dos dentes baseado numa pontuacao imaginaria
		if (pontuacao < 4 )
		{
			animator1.SetInteger ("Sujeira", 1);
		}
		else if (pontuacao > 3 && pontuacao < 7)
		{
			animator1.SetInteger ("Sujeira", 2);
		}
		else if (pontuacao >6 && pontuacao < 10)
		{
			animator1.SetInteger ("Sujeira", 3);
		}

	}
}
