using UnityEngine;
using System.Collections;

public class movimentoRio : MonoBehaviour {
	float velocidade = 7.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left"))
		{
			transform.Translate(Vector3.left * velocidade * Time.deltaTime);
		}
		if (Input.GetKey("right"))
		{
			transform.Translate(Vector3.right * velocidade * Time.deltaTime);
		}
	}
}
