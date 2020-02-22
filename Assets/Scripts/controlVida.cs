using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlVida : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject sangre;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("p")) {
			this.irAMenuPrincipal();
		}
        this.sangre.GetComponent<Slider>().value = GameObject.Find ("FPSController").GetComponent<vida> ().getSangre();
    }

    public void irAMenuPrincipal(){
        SceneManager.LoadScene("MenuLeft");
        Cursor.visible = true;
    }
}
