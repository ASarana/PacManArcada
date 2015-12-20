﻿using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour 
{
	public Transform Goal; //куда вигаться, сюда впихнем пакмана
	private NavMeshAgent agent; //текущий объект
	private Vector3 zeropos;
	public LevelLogic levellogic;
	private int Level;
	int Ipurp;
	//Vector3[] placesInky;
	public Transform[] test = new Transform[27];

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
//		ghost_transform = GetComponent<Transform> ();
		zeropos = this.transform.position;
		Level = levellogic.levelnum ();
		agent.destination = this.transform.position;


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levellogic.ghostorientation()=="blue" && levellogic.statusghost(this.name)=="life") //если призрак синий, то ему надо повернуться
		{this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));}
		else if (levellogic.ghostorientation()=="natural" && levellogic.statusghost(this.name)=="life") //тут наоборот
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		else  if (levellogic.statusghost(this.name)=="dead") //если мертв
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
		//print (levellogic.ghostorientation());

		if (levellogic.islevelstart ()) 
		{
			if (levellogic.statusghost (this.name) == "life") 
			{ //если призрак жив
				//print(agent.remainingDistance);
				if (agent.remainingDistance == 0) 
				{
					Ipurp = Random.Range (0, 6);
					agent.destination = test [Random.Range (0, 26)].position;
				} 
			} 
			if (levellogic.statusghost (this.name) == "dead")
				agent.destination = zeropos; //если он голубой или мертв, идем в стартовую локацию

			if (levellogic.statusghost (this.name) == "dead" && agent.remainingDistance == 0) //если мертвый пришел в старт, то он оживает
				levellogic.riseghost (this.name);

			if (this.transform.position.x <= (Goal.position.x + 0.5) && this.transform.position.x >= (Goal.position.x - 0.5)
				&& this.transform.position.z <= (Goal.position.z + 0.5) && this.transform.position.z >= (Goal.position.z - 0.5) 
				&& this.transform.position.y <= (Goal.position.y + 2) && this.transform.position.y >= (Goal.position.y - 2)
			) 
			{
				if (levellogic.ghostorientation () == "blue" && levellogic.statusghost (this.name) == "life") 
				{
					levellogic.dieghost (this.name);
					levellogic.incscore(10);
				}
				if (levellogic.ghostorientation () == "natural" && levellogic.statusghost (this.name) == "life") 
				{
					levellogic.diepacman ();
					levellogic.levelstop ();
				}
			}


		} 
		else if (!levellogic.islevelstart () && levellogic.pacmanlifenum()>0) 
		{
			ReturnBase ();
			if (levellogic.levelnum () > Level) 
			{
				agent.acceleration += 2;
				Level = levellogic.levelnum ();

			}
		}
					
	}
	public void ReturnBase()
	{
		this.transform.position = zeropos;
		agent.destination = this.transform.position;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0)); 
		levellogic.makeghostnatural ();
		levellogic.riseghost (this.name);

	}
}
