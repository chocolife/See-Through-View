using UnityEngine;
using System.Collections;

public class SwitchCarObject : MonoBehaviour
{

	private GameObject carInterior;
	private GameObject carExterior;

	private GameObject tire;

	private Camera main_camera;
	private Camera top_camera;

	private Animator transfar_anim;

	public Vector3 pos;

	private bool bodyTransparent = true;

	public StatusManager statusManager;


	// Use this for initialization
	void Start ()
	{
		statusManager = GameObject.Find("Canvas").GetComponent<StatusManager>();

		carInterior = GameObject.Find("Camry_Interior");
		carExterior = GameObject.Find ("Camry_Colored");

		tire =  GameObject.Find ("Camry_Colored/Body");

		transfar_anim = GameObject.Find ("Transfar Camera").GetComponent<Animator>();
		main_camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		top_camera = GameObject.Find ("CamParent/Top Camera").GetComponent<Camera>();
	
		statusManager.interior_visible = false;
	}


	// Update is called once per frame
	void Update ()
	{
		pos = this.transform.position;

		//Is camera located inside?
		if ((pos.z > -3 && this.enabled == true) && top_camera.enabled == false) 
		{
			if (statusManager.interior_visible == false)
			{
				foreach (Transform car_child in carInterior.transform) 
				{
					car_child.GetComponent<Renderer> ().enabled = true;
					iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 0.5f, "time", 1.5f));
				}


				foreach (Transform car_child_ex in carExterior.transform) 
				{
					car_child_ex.GetComponent<Renderer> ().enabled = true;
					iTween.FadeTo(car_child_ex.gameObject, iTween.Hash("alpha", 0, "time", 0.5f));
				}
				statusManager.interior_visible = true;
			}
		}
		else
		{
			if (statusManager.interior_visible == true)
			{	
				foreach (Transform car_child in carInterior.transform)
				{
					car_child.GetComponent<Renderer> ().enabled = true;
					iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 0, "time", 0));
				}
				
				foreach (Transform car_child in carExterior.transform)
				{
					car_child.GetComponent<Renderer> ().enabled = true;
					iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 1.0f, "time", 0));
				}
				statusManager.interior_visible = false;
			}
		}



		if (transfar_anim.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f)
		{
			//transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		}
		else
		{
			//transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);
		}

	}
}