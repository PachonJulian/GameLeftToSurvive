using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class muerteBala : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject mira;
	public GameObject camara;
	public GameObject m16;
	public int balas;
	public float vidaZombie;
	public GameObject shoot;
    void Start()
    {
			this.balas = 160;
			//ReproducirSonido(this.GetComponents<AudioSource>()[0]);
    }

    // Update is called once per frame
    void Update()
    {
		RaycastHit hit;

		Ray rayo = new Ray (this.transform.position, this.transform.forward * 10f);

		if (Input.GetMouseButton (0)) {//Click izquierdo
			if(this.balas <= 0 && this.m16.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("fire")){
				this.m16.GetComponent<m16> ().reload();
				//this.balas = 160;Desde el metodo reload las recarga
			}
			else{
				if(!this.m16.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("reload"))
				{
					this.m16.GetComponent<m16> ().fire();
					this.balas = this.balas - 1;
					GameObject newShoot=Instantiate(shoot,GameObject.Find("PosicionBala").transform.position,Quaternion.identity)as GameObject;
					newShoot.GetComponent<Rigidbody>().AddForce (GameObject.Find ("PosicionBala").transform.forward*40000*Time.deltaTime);
				}
			}
			
			//Vector3 fwd = mira.transform.position;
			
			//print ("balas: " + this.balas);
			//ReproducirSonido(this.GetComponents<AudioSource>()[1]);
			Debug.DrawRay (this.transform.position, this.transform.forward * 10f, Color.green);

			if (Physics.Raycast (rayo, out hit, 10f)) {
				//print ("impacto con: " + hit.collider.name);

				if(hit.collider.name.Equals("hor_mon") || hit.collider.name.Equals("hor_mon(Clone)")){
					if(!GameObject.Find("FPS_m16_01").GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("reload")){
						vidaZombie = hit.collider.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value;
						if(vidaZombie <= 0){
							hit.collider.gameObject.GetComponent<Persecucion> ().muerte();
						}
						else{
							vidaZombie = vidaZombie - 25;
							hit.collider.gameObject.GetComponent<Animator>().SetInteger ("golpe", 1);//golpe
							hit.collider.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = vidaZombie;//Actualiza Slider
						}
					}
				}
			}
		}

		if(Input.GetMouseButtonUp (0)){
				this.m16.GetComponent<m16> ().idle();
		}

		if (Input.GetMouseButtonDown(1))//Click derecho
		{
				this.apuntar();
		}

		if (Input.GetMouseButtonUp(1))//Click derecho
		{
				this.desapuntar();
		}

		if (Input.GetKeyDown ("x")) {
			this.apuntar();
		}
		if (Input.GetKeyUp ("x")) {
			this.desapuntar();
		}

    }
		
	public void ReproducirSonido(AudioSource AudioVista)
	{
		if(!AudioVista.isPlaying)
		{
			AudioVista.Play();
		}
	}

	public void apuntar ()
	{
		this.mira.SetActive (true);
		this.camara.GetComponent<Camera>().fieldOfView = 40.0f; 

	}

	public void desapuntar ()
	{
		this.mira.SetActive (false);
		this.camara.GetComponent<Camera>().fieldOfView = 60.0f; 

	}
}
