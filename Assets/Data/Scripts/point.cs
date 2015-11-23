using UnityEngine;
using System.Collections;

public class point : MonoBehaviour 
{

	public Transform pacman_trans; //сюда подставим пакмана
	private Transform point_trans; //это для манипуляций с точкой
	public int pointcount; //это чтобы знать что уровень закончен количество съеденных точек
	// Use this for initialization
	void Start () 
	{
		point_trans = GetComponent<Transform> (); // берем трансформ текущего объекта - точки
	}
	
	// Update is called once per frame
	void Update () 
	{
		//отследим, что пакман дотронулся до точки
		if (point_trans.position.x <= (pacman_trans.position.x + 0.5) && point_trans.position.x >= (pacman_trans.position.x - 0.5)
		    && point_trans.position.z <= (pacman_trans.position.z + 0.5) && point_trans.position.z >= (pacman_trans.position.z - 0.5) 
		    && point_trans.position.y <= (pacman_trans.position.y + 2) && point_trans.position.y >= (pacman_trans.position.y - 2)
		   ) 
		{
			//сдвинем точку плд платформу, якобы пакман её взял
			print ("Взял");
			point_trans.position= new Vector3(point_trans.position.x,point_trans.position.y-10,point_trans.position.z);
			pointcount++;
		}
	}
}
