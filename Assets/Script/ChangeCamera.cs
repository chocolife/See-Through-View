using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{

	private Camera main_camera;
	private Camera top_camera;
	private Camera transfar_camera;

	private GameObject carInterior;
	private GameObject carExterior;

	private Animator rotate_anim;
	private Animator transfar_anim;
	//private bool interiorTransparent = true;
	
	// Use this for initialization
	void Start ()
	{
		carInterior = GameObject.Find("Camry_Interior");
		carExterior = GameObject.Find ("Camry_Colored");

		main_camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		transfar_camera = GameObject.Find ("Transfar Camera").GetComponent<Camera>();
		top_camera = GameObject.Find ("CamParent/Top Camera").GetComponent<Camera>();

		rotate_anim = GameObject.Find("CamParent").GetComponent<Animator>();
	}


	public void OnClick() 
	{
		if (top_camera.enabled == false) 
		{	
			main_camera.enabled = false;
			transfar_camera.enabled = false;
			top_camera.enabled = true;
			rotate_anim.speed = 1.0f;
		}
		else
		{
			main_camera.enabled = true;
			transfar_camera.enabled = false;
			top_camera.enabled = false;
			rotate_anim.speed = 0;
		}
	}


	// Update is called once per frame
	void Update () 
	{
	
	}
}
