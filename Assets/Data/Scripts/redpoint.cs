using UnityEngine;
using System.Collections;

public class redpoint : MonoBehaviour 
{
	
	public Transform pacman_trans; //сюда подставим пакмана
	/*public Transform clyde;
	public Transform pinky;
	public Transform inky;
	public Transform blinky;*/
	private Vector3 point_trans; //это для манипуляций с точкой
	private float timer;
	//public int pointcount; //это чтобы знать что уровень закончен количество съеденных точек
	public LevelLogic levellogic;
	private Vector3 zeropos;
	private int Level;
	// Use this for initialization
	void Start () 
	{
		point_trans = this.transform.position;
		zeropos = this.transform.position;
		Level = levellogic.levelnum ();

	}
	
	// Update is called once per frame
	void Update () 
	{ 
		//отследим, что пакман дотронулся до точки
		if (this.transform.position.x <= (pacman_trans.position.x + 0.5) && this.transform.position.x >= (pacman_trans.position.x - 0.5)
			&& this.transform.position.z <= (pacman_trans.position.z + 0.5) && this.transform.position.z >= (pacman_trans.position.z - 0.5) 
			&& this.transform.position.y <= (pacman_trans.position.y + 2) && this.transform.position.y >= (pacman_trans.position.y - 2)
		    ) 
		{
			//сдвинем точку плд платформу, якобы пакман её взял
			this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y-10,this.transform.position.z);
			levellogic.makeghostblue();
			timer = Time.time;
			levellogic.incscore(5);
		}

		if (Time.time - timer >= 10 && point_trans.y-10==this.transform.position.y) 
		{
			levellogic.makeghostnatural();
			this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y-10,this.transform.position.z);
		}

		if (!levellogic.islevelstart ()) 
			if (levellogic.levelnum() > Level ||levellogic.levelnum() < Level) 
			{
				ReturnHome();
				Level=levellogic.levelnum();
			}

	}

	public void ReturnHome()
	{
		this.transform.position = zeropos;
	}
}
