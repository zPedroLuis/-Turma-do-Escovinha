using UnityEngine;
using System.Collections;

public class movimentoEscovinha : MonoBehaviour {

	//Variaveis
	public static float velocidade = 0;
	private bool pulo = false;
	private bool correndo = true;
	private float forcaPulo=800;
	private Animator animator;
	public static int vidas = 9;
	private bool lado = true;
	public AudioClip encostaCarie;
	private bool colisaoCarie = false;
	public float tempoCarie = 0;
	public float tempoCenario = 0;
	public bool puloColisao= false;
	public bool movimentoDente= false;
	public bool colisao = false;
	public float ivunerabilidade = 0f;




	void Start () 
	{
		velocidade = 0;
		animator = this.GetComponent<Animator>();
	}	

	void Update () 
	{

		//atribuiçoes das variaveis
		tempoCarie += Time.deltaTime;
		tempoCenario += Time.deltaTime;
		forcaPulo=800;

		// movimento Direita
		if (Input.GetAxisRaw ("Horizontal") > 0)
		{		
			//Caso a colisao com a carie seja falsa, ele se movimentara para o lado Direito
			if (colisaoCarie == false)
			{	
				velocidade = 9;
				transform.Translate(Vector2.right * velocidade * Time.deltaTime);
				lado = true;
			}
		}
		// movimento Esquerda
		else if(Input.GetAxisRaw ("Horizontal") < 0)
		{	//Caso a colisao com a carie seja falsa, ele se movimentara para o lado Esquerdo
			if (colisaoCarie == false)
			{	
				velocidade = 9;
				transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
				lado = false;
			}
		}
		else 		
		{
			velocidade = 0;
		}
			//Pulo e animaçoes do pulo
			if (velocidade == 0 && (!pulo)&&(lado))
			{
				animator.SetInteger ("movimento", 1);
			}
			else if (velocidade == 0 && (!pulo)&&(!lado))
			{
				animator.SetInteger ("movimento", 2);
			}				
				if (Input.GetAxisRaw ("Vertical") > 0 && (!pulo) && (lado))
				{	
					if (puloColisao == false)
					{
						animator.SetInteger ("movimento", 5);
						pulo = true;
						rigidbody2D.AddForce (transform.up * forcaPulo);
						movimentoDente = false;
					}

				} 	
						if (Input.GetAxisRaw ("Vertical") > 0 && (pulo) && (lado))
						{	
							if (puloColisao == false)
							{
								animator.SetInteger ("movimento", 5);
								correndo = false;
								movimentoDente = false;
							}
						} 

							if (Input.GetAxisRaw ("Vertical") > 0 && (!pulo) && (!lado))
							{	
								if (puloColisao == false)
								{
									animator.SetInteger ("movimento", 6);
									pulo = true;
									rigidbody2D.AddForce (transform.up * forcaPulo);
									movimentoDente = false;
								}
							} 
		
									if (Input.GetAxisRaw ("Vertical") > 0 && (pulo) && (!lado))
									{	
										if (puloColisao == false)
										{
											animator.SetInteger ("movimento", 6);
											correndo = false;
											movimentoDente = false;
										}
									} 

											if (Input.GetAxisRaw ("Horizontal") > 0&& (correndo))
											{				
												animator.SetInteger ("movimento", 3);
											}
											else if (Input.GetAxisRaw ("Horizontal") < 0 && (correndo))
											{				
												animator.SetInteger ("movimento", 4);
											}	



												if (tempoCarie >= 6)
												{
													tempoCarie = 0;
												}
													if (tempoCenario >= 4)
													{
														tempoCenario = 0;
													}
														if (movimentoDente == true) 
														{
															if (tempoCenario >= 0 && tempoCenario < 2)	
															{
																transform.Translate(-Vector2.right * 8 * Time.deltaTime);
															}
															if (tempoCenario >= 2 && tempoCenario < 4)
															{
																transform.Translate(Vector2.right * 8 * Time.deltaTime);
															}
															
														}
		if (colisao == true) 
		{
			ivunerabilidade += Time.deltaTime;
		}
		else
		{
			ivunerabilidade = 0;
		}
	}

	//Colisao do personagem
	void OnCollisionEnter2D (Collision2D info)
	{
			colisao = false;
		//colisao com as plataformas paradas
		if(info.gameObject.name == "plataforma" || info.gameObject.name == "denteUnidade")
		{
			puloColisao = false;
			colisaoCarie = false;
			pulo = false;	
			correndo = true;
			movimentoDente = false;
			// ajustes de animaçoes
			if(lado)
			{
				animator.SetInteger ("movimento", 1);
			}
			if(!lado)
			{
				animator.SetInteger ("movimento", 2);
			}
		}
		// colisao com plataformas em movimento, para que ele possa andar junto da plataforma
		if(info.gameObject.name == "plataformaMovimento" || info.gameObject.name == "plataformaMovimento(Clone)")
		{
			puloColisao = false;
			colisaoCarie = false;
			pulo = false;	
			correndo = true;
			movimentoDente = true;
		}
		// colisao com a plataforma "doce"
		if(info.gameObject.name == "Doce")
		{
			puloColisao = false;
			colisaoCarie = false;
			pulo = false;	
			correndo = true;
			movimentoDente = false;
			animator.SetInteger ("movimento", 1);

		}

		//Colisao com as pastas de dente e contador positivo de vidas
		if(info.gameObject.name == "Pasta")
		{
			vidas++;
			Sujeira.pontuacao++;
			Destroy(info.gameObject);
			if(vidas > 9)
			{
				vidas = 9;
			}
		}

			//Colisao com a cabeça das caries, destruira as caries
			if(info.gameObject.name == "esmaga")
			{
				rigidbody2D.AddForce (transform.up * forcaPulo);
				Destroy(info.gameObject);

			}
			//Colisao com o ponto de vitoria
				if (info.gameObject.name == "escovaNivel1") 
				{
					Application.LoadLevel ("Nivel2");
					vidas = vidas;
				}
				if (info.gameObject.name == "escovaNivel2") 
				{
					Application.LoadLevel ("Nivel3");
					vidas = vidas;
				}
				if (info.gameObject.name == "escovaNivel3") 
				{
					Application.LoadLevel ("vitoria");
					vidas = vidas;
				}
				if (info.gameObject.name == "escovaNivel4") 
				{
					Application.LoadLevel ("Nivel5");
					vidas = vidas;
				}
				if (info.gameObject.name == "escovaNivel5") 
				{
					Application.LoadLevel ("vitoria");
					vidas = vidas;
				}

		if(ivunerabilidade == 0)
		{
			// Colisao com as caries e contador negativo de vidas
			if(info.gameObject.name == "Carie")
			{	
				colisao = true;
				puloColisao = true;
				
				audio.clip = encostaCarie;
				audio.Play();

				vidas--;
				Sujeira.pontuacao--;
					// verifica a colisao com a carie, caso haja colisao, o personagem sera repelido
					// para direçao oposta da colisao
					if (Input.GetAxisRaw ("Horizontal") > 0)
					{	
						rigidbody2D.AddForce (transform.up * 200);
						rigidbody2D.AddForce (-transform.right * 50);
						colisaoCarie = true;
						animator.SetInteger ("movimento", 1);
					}
					if(Input.GetAxisRaw ("Horizontal") < 0)
					{			
						rigidbody2D.AddForce (transform.up * 200);
						rigidbody2D.AddForce (transform.right * 50);
						colisaoCarie = true;
						animator.SetInteger ("movimento", 1);
					}
					if(tempoCarie >= 0 && tempoCarie < 3)		
					{
						if(!pulo)
						{
							rigidbody2D.AddForce (transform.up * 700);
						}
						rigidbody2D.AddForce (-transform.right * 300);
						colisaoCarie = true;
						animator.SetInteger ("movimento", 2);
					}
					if(tempoCarie >= 3 && tempoCarie <= 6)		
					{
						if(!pulo)
						{
							rigidbody2D.AddForce (transform.up * 700);
						}
						rigidbody2D.AddForce (transform.right * 300);
						colisaoCarie = true;
						animator.SetInteger ("movimento", 1);
					}
						//Caso as vidas chegue a "zero", a tela de fim de jogo e acionada
						if (vidas == 0)
						{
							Application.LoadLevel("derrota");
						}
			}
		}
			//Caso ele colida diretamente com o rio, a tela de fim de jogo e acionada
			if (info.gameObject.name == "rio_0")
			{
				Application.LoadLevel ("derrota");
			}


	}



}
