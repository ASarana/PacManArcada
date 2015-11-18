using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class pacman_control : MonoBehaviour 
{
	private CharacterController pacman; 
	public Transform pacman_transform;
	public float speed; 
	private Vector3 move;
	private Transform cam; 
	private Vector3 camForward;
	private Vector3 look;
	private float v;
	private float h;
	private float v1;
	private float h1;
	public float colis_dist;
	void Start () 
	{
		pacman = GetComponent<CharacterController>();
		pacman_transform = GetComponent<Transform>();
		cam = Camera.main.transform;
		look = new Vector3 (100, 0, 0);
		v = 0; 
		h = 0;
		v1 = 0;
		h1 = 0;
	}
	
	void Update () 
	{ 
		if (v==0)	h = CrossPlatformInputManager.GetAxis("Horizontal");
		if (h==0) 	v = CrossPlatformInputManager.GetAxis("Vertical");
		
		if (h > 0 && h > h1)  h1 = 1;
		if (v > 0 && v > v1)  v1 = 1;
		if (h < 0 && h < h1)	h1 = -1;
		if (v < 0 && v < v1)	v1 = -1;
		if (h == 0 && v != 0)	h1 = 0;
		if (v == 0 && h != v)	v1 = 0;
		
		
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		move = (v1*camForward + h1*cam.right).normalized;
		if (h == h1 && v == v1 && h == 0 && v == 0 && h1 == 0 && v1 == 0)
			look.Set (100, 0, 0);
		else look = (v1 * camForward + h1 * cam.right) * 1000;
		
		if (Physics.Raycast (pacman_transform.position, pacman_transform.forward, colis_dist))
			print ("forward");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.forward, colis_dist))
			print ("back");
		if (Physics.Raycast (pacman_transform.position, pacman_transform.right, colis_dist))
			print ("right");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.right, colis_dist))
			print ("left");
	}
	
	private void FixedUpdate()
	{
		pacman.Move(speed*move);
		pacman_transform.LookAt (look);
	}
}
