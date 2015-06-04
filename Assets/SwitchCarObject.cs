using UnityEngine;
using System.Collections;

public class SwitchCarObject : MonoBehaviour {

	private GameObject carInterior;
	private GameObject carExterior;
	private Vector3 pos;

	private bool interiorTransparent = true;
	private bool ExteriorTransparent = false;

	// Use this for initialization
	void Start () {
		//Instantiate(GameObject.Find("Camry_New_ADD_03_light_02"));

		carInterior = GameObject.Find("Camry_Interior");
		carExterior = GameObject.Find ("Camry_Colored");

		//Transform[] tr_child = carExterior.GetComponentsInChildren();



		//carExterior.GetComponent<Renderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (carInterior == null) {
			Debug.Log ("NULL!!!!");
		}
		pos = this.transform.position;
		Debug.Log (pos.z);

		if (pos.z < -3) {
			interiorTransparent = false;
		} else {
			interiorTransparent = true;
		}
		foreach (Transform car_child in carInterior.transform) {
			car_child.GetComponent<Renderer> ().enabled = interiorTransparent;
		}

		foreach (Transform car_child in carExterior.transform) {
			car_child.GetComponent<Renderer> ().enabled = !interiorTransparent;
		}
	}
}