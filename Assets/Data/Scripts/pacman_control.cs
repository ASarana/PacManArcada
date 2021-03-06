﻿using UnityEngine;
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
	public float colis_dist;
	public float stop_dist;
	//public Transform zeropos;
	private Vector3 zeropos;
	public LevelLogic levellogic;
	private int Level;
	private float Y; //поворот пакмана
	RaycastHit hitinfo;
	Vector3 forray;
	float anglerot;
	public int rotatespeed;
	int i;
	public float raylevel;
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
		anglerot = 180;
		i = 0;
	}

	void Update () 
	{  
		//вычислим луч, который будет стелится по рельсе для проверки столкновений
		forray = new Vector3 (this.transform.position.x, this.transform.position.y - raylevel, this.transform.position.z);

	/*	Debug.DrawRay (forray, Vector3.right, Color.green); 
		Debug.DrawRay (forray, -Vector3.right, Color.green); 
		Debug.DrawRay (forray, Vector3.forward, Color.green); 
		Debug.DrawRay (forray, -Vector3.forward, Color.green); */

	//надо
		Quaternion qq = this.transform.rotation;
		Vector3 vv = qq.eulerAngles;

		if (levellogic.islevelstart ()) {
			//можем поворачивать только если есть куда повернуть
			if (v == 0 && (!Physics.Raycast (forray, Vector3.right, colis_dist) || (!Physics.Raycast (forray, -Vector3.right, colis_dist))))
				h = CrossPlatformInputManager.GetAxis ("Horizontal");
			if (h == 0 && (!Physics.Raycast (forray, Vector3.forward, colis_dist) || (!Physics.Raycast (forray, -Vector3.forward, colis_dist))))
				v = CrossPlatformInputManager.GetAxis ("Vertical");

			//это чтобы пакман ехал непрерывно и по горизонтали + смотрел в сторону движения
			if (h > 0 && h > h1 && !Physics.Raycast (forray, Vector3.right, colis_dist) && v == 0) {
				h1 = 1;
				Y = 90;
				v1 = 0;
				anglerot = vv.y;
				i = 0;
			}
			if (v > 0 && v > v1 && !Physics.Raycast (forray, Vector3.forward, colis_dist) && h == 0) {
				v1 = 1;
				Y = 0;
				h1 = 0;
				anglerot = vv.y;
				i = 0;
			}
			if (h < 0 && h < h1 && !Physics.Raycast (forray, -Vector3.right, colis_dist) && v == 0) {
				h1 = -1;
				Y = 270;
				v1 = 0;
				anglerot = vv.y;
				i = 0;
			}
			if (v < 0 && v < v1 && !Physics.Raycast (forray, -Vector3.forward, colis_dist) && h == 0) {
				v1 = -1;
				Y = 180;
				h1 = 0;
				anglerot = vv.y;
				i = 0;
			}
	

			//остановка когда утыкается 
			if (h == 0 && (Physics.Raycast (forray, Vector3.right, stop_dist) || Physics.Raycast (forray, -Vector3.right, stop_dist)))
				h1 = 0;
			if (v == 0 && (Physics.Raycast (forray, Vector3.forward, stop_dist) || Physics.Raycast (forray, -Vector3.forward, stop_dist)))
				v1 = 0;
			/*if (h == h1 && v == v1 && h == 0 && v == 0 && h1 == 0 && v1 == 0)
				Y=180;*/

			//рассчитаем перпендикуляр к камере
			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
			//рассчитаем вектор движения пакмана
			move = (v1 * camForward + h1 * cam.right).normalized;
			pacman.Move(speed*move); //двигаем пакмана
			pacman.Move(-Vector3.up);
			this.transform.rotation = Quaternion.Euler(new Vector3(0, Y, 0)); //поворачиваем по направлению

		} 

		else if (!levellogic.islevelstart ())
		{
			ReturnHome ();
			if (levellogic.levelnum () > Level || levellogic.levelnum () < Level) 
			{
				Level = levellogic.levelnum ();
			//	speed = speed + (float)0.01;
			}

		}
			

	/*	if (Y >= 0 && Y <= 180)
			if (i < Mathf.Abs(Mathf.Min (360 - Y, Y) - Mathf.Min (360 - anglerot, anglerot))) 
		        { 
				if(Mathf.Min (360 - Y, Y) - Mathf.Min (360 - anglerot, anglerot) > 0)
				this.transform.Rotate (new Vector3 (0, rotatespeed , 0));
				if(Mathf.Min (360 - Y, Y) - Mathf.Min (360 - anglerot, anglerot) < 0)
				this.transform.Rotate (new Vector3 (0, -rotatespeed , 0));
			i=i+rotatespeed;
				}
		if (Y>180 && Y<360)
		if (i < Mathf.Abs(Mathf.Min (360 - anglerot, anglerot) - Mathf.Min (360 - Y, Y))) 
			{ 
				if(Mathf.Min (360 - anglerot, anglerot) - Mathf.Min (360 - Y, Y)>0)
				this.transform.Rotate (new Vector3 (0, rotatespeed, 0));
				if(Mathf.Min (360 - anglerot, anglerot) - Mathf.Min (360 - Y, Y)<0)
				this.transform.Rotate (new Vector3 (0, -rotatespeed , 0));
			i=i+rotatespeed;
			}
	*/
	}

	public void ReturnHome()
	{
		this.transform.position = zeropos;
		h1 = 0;
		v1 = 0;
		Y=180;
		move = (v1 * camForward + h1 * cam.right).normalized;
		this.transform.rotation = Quaternion.Euler(new Vector3(0, Y, 0)); //поворачиваем по направлению
	}	
}
