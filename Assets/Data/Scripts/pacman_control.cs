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
	void Start () 
	{
		pacman = GetComponent<CharacterController>();
		pacman_transform = GetComponent<Transform>();
		cam = Camera.main.transform;
	}
	
	void Update () 
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		move = (v*camForward + h*cam.right).normalized;
		pacman_transform.LookAt (new Vector3(h*1000,0,v*1000));
	
	}

	private void FixedUpdate()
	{
			pacman.Move(speed*move);
	}

	void OnCollisionEnter() 
	{


	}
}
