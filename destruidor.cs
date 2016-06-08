using UnityEngine;
using System.Collections;

public class destruidor : MonoBehaviour {

	float velocidade;
	void Start () 
	{
		//velocidade = 7.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(Vector3.right * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D info)
	{
		if (info.gameObject.name == "plataforma") 
		{		
			Destroy(info.gameObject);
		}
		if (info.gameObject.name == "Pasta") 
		{		
			Destroy(info.gameObject);
		}
		if (info.gameObject.name == "Carie") 
		{		
			Destroy(info.gameObject);
		}
		if (info.gameObject.name == "Doce") 
		{		
			Destroy(info.gameObject);
		}
	}
}
