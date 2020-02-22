using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class btnIniciar : MonoBehaviour
{
    // Start is called before the first frame update
    CursorLockMode wantedMode;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = wantedMode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void iniciarLevel1() {
        SceneManager.LoadScene("scene1");

    }

    public void iniciarLevel2()
    {
        SceneManager.LoadScene("Civilian scene");

    }

    public void iniciarLevel3()
    {
        SceneManager.LoadScene("Night scene");

    }

    public void iniciarLevel4()
    {
        SceneManager.LoadScene("Prototype scene");

    }
}
