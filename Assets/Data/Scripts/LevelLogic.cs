using UnityEngine;
using System.Collections;

public class LevelLogic : MonoBehaviour 
{
	private int countpoint;
	private int level;
	private bool levelstart;
	private float timer;
	private bool pacmandie;
	private int pacmanlife;



	void Start () 
	{
		countpoint = 0;
		level = 1;
		levelstart = false;
		timer = Time.time;
		pacmanlife = 3;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (countpoint == 8) 
		{
			level++;
			levelstart=false;
			countpoint=0;
			timer = Time.time;	

		}

		if (levelstart==false && Time.time - timer >= 3 && pacmanlife>0)
		{
			levelstart=true;
			pacmandie = false;
		}

		if (pacmandie == true & levelstart == true) 
		{
			if (pacmanlife > 0) 
			{

				pacmanlife--;
				timer = Time.time;
				levelstart=false;

			}
			else levelstart=false;
		}

	}

	//проедура увеличения количества съеденных точек
	public void TakePoint()
	{
		countpoint++;
	}
	//функция чтобы показать сколько точек скушали
	public int TakenPoints()
	{
		return countpoint;
	}
	public int levelnum()
	{
		return level;
	}
	public bool islevelstart()
	{
		return levelstart;
	}

	public bool ispacmandie()
	{
		return pacmandie;
	}
	public int pacmanlifenum()
	{
		return pacmanlife;
	}
	public void diepacman()
	{
		 pacmandie = true;
	}
}
