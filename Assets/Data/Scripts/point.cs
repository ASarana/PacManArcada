using UnityEngine;
using System.Collections;

public class point : MonoBehaviour 
{

	public Transform pacman_trans; //сюда подставим пакмана
	public LevelLogic LevelLogic;
	private Vector3 zeropos;
	private int Level;
	// Use this for initialization
	void Start () 
	{
		zeropos = this.transform.position;
		Level = LevelLogic.levelnum ();
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
			LevelLogic.TakePoint(); //увеличиваем переменну отвечающую за взятые точки
			LevelLogic.incscore(1);
		}

		if (LevelLogic.levelnum() > Level) 
		{
			ReturnHome();
			Level=LevelLogic.levelnum();
		}


	}
	public void ReturnHome()
	{
		this.transform.position = zeropos;
	}
}
