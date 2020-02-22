using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Persecucion : MonoBehaviour
{

    Vector3 PIniicial; //Punto inicial
    public Ray Inicio;
    public RaycastHit Objetivo;
    public bool blocked;
    public GameObject jugador;
    NavMeshAgent Agente;
	public bool vida;
	public float vidaZombie;

    // Use this for initialization
    void Start()
    {
        this.PIniicial = this.gameObject.transform.position;
        this.blocked = false;
        this.Agente = this.GetComponent<NavMeshAgent>();
		this.vida = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (this.vida) {
			NavMeshHit hit;
			this.blocked = NavMesh.Raycast (this.transform.position, this.jugador.transform.position, out hit, NavMesh.AllAreas);
			Debug.DrawLine (transform.position, this.jugador.transform.position, blocked ? Color.green : Color.red);
			if(!this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("golpe")){
				if ((hit.distance < 150f) && (!blocked)) {
					if (!this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Atacar") && this.vida) {//Si no esta atacando.
						Seguir (this.jugador.transform.position);
					}
					//ReproducirSonido (GetComponents<AudioSource> () [1]);
				}
				else 
				{
					this.GetComponent<Animator> ().SetInteger ("estado", 1);//Se pone a caminar
					this.GetComponent<Animator> ().SetInteger ("ataque", 0);//No atacar
					//this.GetComponent<Animator> ().SetInteger ("golpe", 0);//No atacar
					//ReproducirSonido (GetComponents<AudioSource> () [1]);//Sonido de caminar
					Regresar (PIniicial);
				}
				if (Vector3.Distance (this.gameObject.transform.position, PIniicial) < 2f) {
					if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Atacar")) {
						this.GetComponent<Animator> ().SetInteger ("ataque", 0);//No Atacar
					}
					//this.GetComponent<Animator>().SetInteger ("golpe", 0);//No golpe
					this.GetComponent<Animator> ().SetInteger ("estado", 0);//idle
				}
			}
			else{
				this.GetComponent<Animator> ().SetInteger ("golpe", 0);
			}
		}
    }
    public void Seguir(Vector3 Objetivo)
    {
		Objetivo = Atacar(Objetivo);//Retorna la nueva posicion del jugador
        this.Agente.destination = Objetivo;
        this.GetComponent<Animator>().SetInteger("estado", 1);//Se pone a caminar 
    }

	public void muerte(){
		this.GetComponent<Animator> ().SetBool("muerte", true);//morir
		this.vida = false;
		ReproducirSonido(GameObject.Find("SoundDeath").GetComponents<AudioSource>()[0]);
		Destroy (this.gameObject, 5f);//5 segundos para morir
	}

	public void Regresar(Vector3 Objetivo){			
		this.Agente.destination = Objetivo;
	}

    public void ReproducirSonido(AudioSource AudioVista)
    {
        if(!AudioVista.isPlaying)
        {
            AudioVista.Play();
        }
    }

	private void OnTriggerEnter(Collider other)//other es con lo que colisiono
	{
		if (other.name.Equals("obstaculo")) {
			this.vida = false;
			muerte ();
		}

		if (other.name.Equals("grenade") || other.name.Equals("grenade(Clone)")) {
			vidaZombie = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value;
			if(vidaZombie <= 0){
				this.vida = false;
				muerte();
			}
			else{
				vidaZombie = vidaZombie - 100;
				this.gameObject.GetComponent<Animator>().SetInteger ("golpe", 1);//golpe
				this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = vidaZombie;//Actualiza Slider
			}
		}

		if (other.name.Equals("shoot") || other.name.Equals("shoot(Clone)")) {
			vidaZombie = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value;
			if(vidaZombie <= 0){
				this.vida = false;
				muerte();
			}
			else{
				vidaZombie = vidaZombie - 25;
				this.gameObject.GetComponent<Animator>().SetInteger ("golpe", 1);//golpe
				this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = vidaZombie;//Actualiza Slider
			}
		}
	}

	public Vector3 Atacar(Vector3 Objetivo)
	{
		float distancia = Vector3.Distance (this.transform.position, this.jugador.transform.position);
		if (distancia <= 2f) {//la distancia de ataque
			Objetivo = this.transform.position;//Para no avanzar el personaje
			this.GetComponent<Animator> ().SetInteger ("estado", 1);//Caminar
			this.GetComponent<Animator> ().SetInteger ("ataque", 1);//Atacar
			ReproducirSonido(GetComponents<AudioSource>()[0]);//Sonido de golpe
		} else {
			if (this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Atacar")) {
				this.GetComponent<Animator> ().SetInteger ("ataque", 0);//No Atacar
			}
			this.GetComponent<Animator> ().SetInteger ("estado", 1);//Caminar
		}
		return(Objetivo);
	}
}
