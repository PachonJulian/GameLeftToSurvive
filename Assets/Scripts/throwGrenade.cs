using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwGrenade : MonoBehaviour
{
    public GameObject granada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown("g"))
      {
        lanzamiento();
      }
    }

    public void  lanzamiento()
    {
		GameObject objGranada=Instantiate(granada,GameObject.Find("PosicionGranada").transform.position,Quaternion.identity)as GameObject;
		objGranada.GetComponent<Rigidbody>().AddForce (GameObject.Find ("PosicionGranada").transform.forward*40000*Time.deltaTime);
    
    ReproducirSonido(GameObject.Find("SoundExplotion").GetComponents<AudioSource>()[0]);
    }

    public void ReproducirSonido(AudioSource AudioVista)
    {
      AudioVista.Play();
    }
}

