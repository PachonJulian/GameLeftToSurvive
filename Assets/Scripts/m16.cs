using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m16 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reload
        if (Input.GetKeyDown ("r")) {
			this.reload();
		}

        if (Input.GetKeyUp ("r")) {
			this.idle();
		}		
    }

    public void idle(){
        this.GetComponent<Animator> ().SetInteger("state", 0);
        this.stopSound(GetComponents<AudioSource> () [0]);
    }

    public void reload(){
        this.GetComponent<Animator> ().SetInteger("state", 1);//Reload
        this.stopSound(GetComponents<AudioSource> () [0]);
        this.playSound (GetComponents<AudioSource> () [1]);//Reload Gun
        GameObject.Find("FPSController").GetComponent<muerteBala> ().balas = 160;
    }

    public void fire(){
        //print("fuego");
        this.GetComponent<Animator> ().SetInteger("state", 2);//firing
        if(!GetComponents<AudioSource> () [1].isPlaying){//Si no esta sonando el de la recarga, entonces puede sonar el disparo
            this.playSound (GetComponents<AudioSource> () [0]);//Firing Gun
        }
    }

    public void playSound(AudioSource AudioVista)
	{
		if(!AudioVista.isPlaying)
		{
			AudioVista.Play();
		}
	}

    public void stopSound(AudioSource AudioVista)
	{
		if(AudioVista.isPlaying)
		{
			AudioVista.Stop();
		}
	}
    
}
