using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vida : MonoBehaviour
{
    // Start is called before the first frame update
	public int sangre;

    void Start()
    {
		this.sangre = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)//other es con lo que colisiono
	{
		
		if (other.name.Equals ("hor_mon") || other.name.Equals ("hor_mon(Clone)")) {
			if(other.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("Atacar")){
				if(other.gameObject.GetComponent<Persecucion>().vida){//Si el enemigo esta vivo
					if (this.sangre >-1) {
						this.sangre = this.sangre - 25;
					}
					else {
						SceneManager.LoadScene("GameOver");
					}
				}
			}
		}
	}

	public int getSangre(){
		return this.sangre;
	}

	public void ReproducirSonido(AudioSource AudioVista)
    {
      AudioVista.Play();
    }
}
