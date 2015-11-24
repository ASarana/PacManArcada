using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class pacman_control : MonoBehaviour 
{
	private CharacterController pacman; //контроллер пакмана чтобы его двигать
	public CharacterController mainc;  //контроллер камеры, чтобы двигать её
	public Transform pacman_transform; //это чтобы колизи отслеживать
	public float speed; //скорость пакмана и камеры
	private Vector3 move; //вектор движения пакмана
	private Transform cam; //это чтобы рассчитать движение пакмана относительно камеры
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
		//разрешаем нажимать кнопку если отпущена вторая. можно убрать впринципе
		if (v==0)	h = CrossPlatformInputManager.GetAxis("Horizontal");
		if (h==0) 	v = CrossPlatformInputManager.GetAxis("Vertical");

		//это чтобы пакман ехал непрерывно и по горизонтали 
		if (h > 0 && h > h1)  h1 = 1;
		if (v > 0 && v > v1)  v1 = 1;
		if (h < 0 && h < h1)	h1 = -1;
		if (v < 0 && v < v1)	v1 = -1;
		if (h == 0 && v != 0)	h1 = 0;
		if (v == 0 && h != 0)	v1 = 0;


	
		
		//рассчитаем перпендикуляр к камере
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		//рассчитаем вектор движения пакмана
		move = (v1*camForward + h1*cam.right).normalized;

		//рассчитаем его взгляд
		if (h == h1 && v == v1 && h == 0 && v == 0 && h1 == 0 && v1 == 0)
			look.Set (100, 0, 0);
		else look = (v1 * camForward + h1 * cam.right) * 1000;

		//это для колизий
		/*if (Physics.Raycast (pacman_transform.position, pacman_transform.forward, colis_dist))
			print ("forward");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.forward, colis_dist))
			print ("back");
		if (Physics.Raycast (pacman_transform.position, pacman_transform.right, colis_dist))
			print ("right");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.right, colis_dist))
			print ("left");*/


	}
	
	private void FixedUpdate()
	{
		pacman.Move(speed*move); //двигаем пакмана
		pacman_transform.LookAt (look); // поворачиваем его в сторону движения
		if (!Physics.Raycast (pacman_transform.position, pacman_transform.forward, colis_dist)) 
		mainc.Move(speed*move); // двигаем камеру за пакманом
	}
}
