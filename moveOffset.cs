using UnityEngine;
using System.Collections;

public class moveOffset : MonoBehaviour {
	
	public float scrollSpeed;
	private Vector2 savedOffset;
	float passagem;
	
	void Start () 
	{
		passagem = 0.5f;
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}
	
	void Update () 
	{
		float x = Mathf.Repeat (scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, savedOffset.y);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);

		if (Input.GetAxisRaw ("Horizontal") > 0)
		{
			scrollSpeed += passagem * Time.deltaTime;
		}

		if(Input.GetAxisRaw ("Horizontal") < 0)
		{	
			scrollSpeed -= passagem * Time.deltaTime;
		}
		else 
		{
			offset = offset;
		}


	}
	
	void OnDisable () {
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}