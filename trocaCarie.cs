using UnityEngine;
using System.Collections;

public class trocaCarie : MonoBehaviour {
	
	private Animator animator;
	float tempo = 0;
	// Use this for initialization
	void Start () 
	{	
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		tempo += Time.deltaTime;
		if (tempo >= 0 && tempo < 31)	
		{
			animator.SetInteger ("lado", 1);
		}
		if (tempo >= 3 && tempo < 6)
		{
			animator.SetInteger ("lado", 0);
		}
		if (tempo >= 6)
		{
			tempo = 0;
		}
		
	}
}
