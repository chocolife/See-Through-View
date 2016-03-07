using UnityEngine;
using System.Collections;

public class SwitchCarObject : MonoBehaviour
{

	private GameObject carInterior;
	private GameObject carExterior;

	private Camera main_camera;
	private Camera top_camera;

	public Vector3 pos;

	private bool bodyTransparent = true;
	//private bool ExteriorTransparent = false;


	// Use this for initialization
	void Start ()
	{
		//Instantiate(GameObject.Find("Camry_New_ADD_03_light_02"));

		carInterior = GameObject.Find("Camry_Interior");
		carExterior = GameObject.Find ("Camry_Colored");

		main_camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		top_camera = GameObject.Find ("CamParent/Top Camera").GetComponent<Camera>();
	
		//Transform[] tr_child = carExterior.GetComponentsInChildren();
		//carExterior.GetComponent<Renderer>().enabled = true;
	}


	// Update is called once per frame
	void Update ()
	{
		pos = this.transform.position;
		//Debug.Log (pos.z);

		//Is camera located inside?
		if ((pos.z > -3 && this.enabled == true) && top_camera.enabled == false) 
		{
			foreach (Transform car_child in carInterior.transform) 
			{
				car_child.GetComponent<Renderer> ().enabled = true;
			}
			
			foreach (Transform car_child in carExterior.transform) 
			{
				car_child.GetComponent<Renderer> ().enabled = false;
			}
		}
		else
		{
			foreach (Transform car_child in carInterior.transform)
			{
				car_child.GetComponent<Renderer> ().enabled = false;
			}
			
			foreach (Transform car_child in carExterior.transform)
			{
				car_child.GetComponent<Renderer> ().enabled = true;
			}
		}

	}
}