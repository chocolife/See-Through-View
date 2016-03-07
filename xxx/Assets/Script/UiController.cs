using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
	
	private Text pos_x;
	private Text pos_y;
	private Text pos_z;

	public Button myButton;
	public Canvas canvas;

	private GameObject main_camera;
	private GameObject top_camera;
	private GameObject transfar_camera;

	private Vector3 cameraPos;
	private Vector3 cameraRot;
	
	private Animator transfar_anim;
	private GameObject transfar_status;
	private GameObject rotation_status;



	// Use this for initialization
	void Start () 
	{

		main_camera = GameObject.Find ("Main Camera");
		top_camera = GameObject.Find ("CamParent/Top Camera"); 
		transfar_camera = GameObject.Find ("Transfar Camera");

		transfar_camera.GetComponent<Camera>().enabled = true;
		main_camera.GetComponent<Camera>().enabled = false;
		top_camera.GetComponent<Camera>().enabled = false;

		transfar_anim = transfar_camera.GetComponent<Animator>();

		pos_x = GameObject.Find("Canvas/pos_x").GetComponent<Text>();
		pos_y = GameObject.Find("Canvas/pos_y").GetComponent<Text>();
		pos_z = GameObject.Find("Canvas/pos_z").GetComponent<Text>();
		transfar_status = GameObject.Find("Canvas/Transfar Status");

		transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);

	}



	// Update is called once per frame
	void Update ()
	{

		//if (transfar_anim.GetCurrentAnimatorStateInfo (0).IsName ("Camera Start"))
		if (transfar_anim.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f)
		{
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			Debug.Log ("Animating!!!!!!");
		}
		else
		{
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);
			Debug.Log ("Stopped!!!!!!");
			main_camera.GetComponent<Camera>().enabled = true;
			transfar_camera.GetComponent<Camera>().enabled = false;
		}

		/*
		if (animation.IsPlaying ("Camera Start")) {
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		} else {
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);
		}
		*/

		cameraRot  = main_camera.transform.eulerAngles;
		pos_x.text = cameraRot.x.ToString();
		pos_y.text = cameraRot.y.ToString();
		pos_z.text = cameraRot.z.ToString();
	
	}
}
