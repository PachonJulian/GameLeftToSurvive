using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backMenu : MonoBehaviour
{
    CursorLockMode wantedMode;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = wantedMode;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("p")) {
			this.irAMenuPrincipal();
		}
    }

    public void irAMenuPrincipal(){
        SceneManager.LoadScene("MenuLeft");
        Cursor.visible = true;
    }
}
