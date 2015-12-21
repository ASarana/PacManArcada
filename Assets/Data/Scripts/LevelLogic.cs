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
	private string orientationghost;
	
	private string	Clydestatus;
	private string	Pinkystatus;
	private string	Inkystatus;
	private string	Blinkystatus;
	int score;




	void Start () 
	{
		countpoint = 0;
		level = 1;
		levelstart = false;
		timer = Time.time;
		pacmanlife = 3;
		orientationghost="natural";
		Clydestatus="life";
		Pinkystatus="life";
		Inkystatus="life";
		Blinkystatus="life";
		score = 0;
	}

	// Update is called once per frame
	void Update () 
	{

		if (countpoint == 146) 
		{
			levelstart=false;
			level++;
			countpoint=0;
			timer = Time.time;	

		}

		if (levelstart==false && pacmanlife==0)
		{
			pacmanlife = 3;
			score = 0;
		}

		if (levelstart==false && Time.time - timer >= 3)
		{
			levelstart=true;
			pacmandie = false;
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
	public void levelstop()
	{
		levelstart = false;
		timer = Time.time;
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
		pacmanlife--;
	}
	public void makeghostblue()
	{
		orientationghost = "blue";
	}
	public void makeghostnatural()
	{
		orientationghost = "natural";
	}
	public void dieghost(string name)
	{
		if (name == "Clyde")
			Clydestatus = "dead";
		else if (name == "Pinky")
			Pinkystatus = "dead";
		else if (name == "Inky")
			Inkystatus = "dead";
		else if (name == "Blinky")
			Blinkystatus = "dead";
		/*else 
			print ("error name diehost");*/

	}
	public string statusghost(string name)
	{
		if (name == "Clyde")
			return Clydestatus;
		else if (name == "Pinky")
			return Pinkystatus;
		else if (name == "Inky")
			return Inkystatus;
		else if (name == "Blinky")
			return Blinkystatus;
		else
			return "error";

	}
	public void riseghost(string name)
	{
		if (name == "Clyde")
			Clydestatus = "life";
		if (name == "Pinky")
			Pinkystatus = "life";
		if (name == "Inky")
			Inkystatus = "life";
		if (name == "Blinky")
			Blinkystatus = "life";
		/*else
			print ("error name risehost");*/
	}

	public string ghostorientation()
	{
		return orientationghost;
	}
	public void incscore(int N)
	{
		score=score+N;
	}
	public int showscore()
	{
		return score;
	}
		
}
