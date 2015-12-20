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
	// Use this for initialization
	void Start () 
	{
		point_trans = this.transform.position;

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
		//	print ("Держитесь, суки");
			this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y-10,this.transform.position.z);
			//pointcount++;
			levellogic.makeghostblue();
			timer = Time.time;
		}

		if (Time.time - timer >= 10 && point_trans.y-10==this.transform.position.y) 
		{
			levellogic.makeghostnatural();
			//print (timer);
			this.transform.position= new Vector3(this.transform.position.x,this.transform.position.y-10,this.transform.position.z);
		}

	}
}
