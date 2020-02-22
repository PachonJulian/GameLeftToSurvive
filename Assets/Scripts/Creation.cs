using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creation : MonoBehaviour {

	[Header("Zombies")]
	public GameObject character;
	private GameObject[] positions;

	// Use this for initialization
	void Start () {
		/*positions = GameObject.FindGameObjectsWithTag("Position");
		foreach (GameObject position in positions) {
			var cyclop = Instantiate(character, position.transform.position, position.transform.rotation);
			cyclop.GetComponent<Enemy> ().player = character.GetComponent<Enemy> ().player;

		}*/
		lanzamiento();

	}
	public void  lanzamiento()
    {
		positions = GameObject.FindGameObjectsWithTag("mateo");
		//positions = GameObject.Find("mateo");
		foreach (GameObject position in positions) {
			GameObject objZombie=Instantiate(character,position.transform.position,Quaternion.identity)as GameObject;
			objZombie.GetComponent<Persecucion> ().jugador = GameObject.Find("FPSController");
			objZombie.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>().value = 1000;
			//objGranada.GetComponent<Rigidbody>().AddForce (position.transform.forward*40000*Time.deltaTime);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
