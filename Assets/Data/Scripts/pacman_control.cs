using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class pacman_control : MonoBehaviour 
{
	private CharacterController pacman; //контроллер пакмана чтобы его двигать
	public float speed; //скорость пакмана и камеры
	private Vector3 move; //вектор движения пакмана
	private Transform cam; //это чтобы рассчитать движение пакмана относительно камеры
	private Vector3 camForward;
	private float v;
	private float h;
	private float v1;
	private float h1;
	//public float colis_dist;
	//public Transform zeropos;
	private Vector3 zeropos;
	public LevelLogic levellogic;
	private int Level;
	private float Y; //поворот пакмана
	void Start () 
	{
		pacman = GetComponent<CharacterController>();
		cam = Camera.main.transform;
		v = 0; 
		h = 0;
		v1 = 0;
		h1 = 0;
		zeropos = this.transform.position;
		Level = levellogic.levelnum ();
		Y = 180;
	}
	
	void Update () 
	{ 
		if (levellogic.islevelstart ()== true) {
			//разрешаем нажимать кнопку если отпущена вторая. можно убрать впринципе
			if (v == 0)
				h = CrossPlatformInputManager.GetAxis ("Horizontal");
			if (h == 0)
				v = CrossPlatformInputManager.GetAxis ("Vertical");


			//это чтобы пакман ехал непрерывно и по горизонтали + смотрел в сторону движения
			if (h > 0 && h > h1)
			{h1 = 1; Y=90;}
			if (v > 0 && v > v1)
			{v1 = 1; Y=0;}
			if (h < 0 && h < h1)
			{h1 = -1; Y=-90;}
			if (v < 0 && v < v1)
			{v1 = -1; Y=180;}
			if (h == 0 && v != 0)
				h1 = 0;
			if (v == 0 && h != 0)
				v1 = 0;
			if (h == h1 && v == v1 && h == 0 && v == 0 && h1 == 0 && v1 == 0)
				Y=180;

			//рассчитаем перпендикуляр к камере
			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
			//рассчитаем вектор движения пакмана
			move = (v1 * camForward + h1 * cam.right).normalized;


			//это для колизий
			/*if (Physics.Raycast (pacman_transform.position, pacman_transform.forward, colis_dist))
			print ("forward");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.forward, colis_dist))
			print ("back");
		if (Physics.Raycast (pacman_transform.position, pacman_transform.right, colis_dist))
			print ("right");
		if (Physics.Raycast (pacman_transform.position, -pacman_transform.right, colis_dist))
			print ("left");*/
			if (levellogic.levelnum () > Level) 
			{

				ReturnHome ();
				h1 = 0;
				v1 = 0;
				//рассчитаем его взгляд
				Y=180;
				Level = levellogic.levelnum ();
				speed = speed + (float)0.1;
			}

			if (levellogic.ispacmandie() == true && levellogic.pacmanlifenum() > 0) 
			{
				ReturnHome ();
				h1 = 0;
				v1 = 0;
				move = (v1 * camForward + h1 * cam.right).normalized;
				Y=180;
			}

		}
		if (levellogic.ispacmandie() == true  && levellogic.pacmanlifenum() > 0) 
		{
			ReturnHome ();
			h1 = 0;
			v1 = 0;
			move = (v1 * camForward + h1 * cam.right).normalized;
			Y=180;
		}
		else if (levellogic.ispacmandie() == true  && levellogic.pacmanlifenum() <= 0) 
		{
			h1 = 0;
			v1 = 0;
			move = (v1 * camForward + h1 * cam.right).normalized;
			Y=180;
		}
	}
	
	private void FixedUpdate()
	{
		pacman.Move(speed*move); //двигаем пакмана
		this.transform.rotation = Quaternion.Euler(new Vector3(0, Y, 0)); //поворачиваем по направлению
	}

	public void ReturnHome()
	{
		this.transform.position = zeropos;
	}	
}
