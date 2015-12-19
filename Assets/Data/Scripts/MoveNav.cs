using UnityEngine;
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
	/*	placesInky = new Vector3[7];
		placesInky [0].Set ((float)2.8, (float)3.17, (float)26.95);
		placesInky [1].Set ((float)9.8, (float)3.17, (float)24.94);
		placesInky [2].Set ((float)9.8, (float)3.17, (float)20.92);
		placesInky [3].Set ((float)5.8, (float)3.17 ,(float)18.91);		
		placesInky [4].Set ((float)7.8, (float)3.17, (float)14.93);
		placesInky [5].Set ((float)9.8, (float)3.17, (float)8.94);
		placesInky [6].Set ((float)3.8, (float)3.17, (float)10.9);
		Ipurp = Random.Range (0, 6);*/
		agent.destination = test [Random.Range(0,26)].position;


	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levellogic.ghostorientation()=="blue" && levellogic.statusghost(this.name)=="life") //если призрак синий, то ему надо повернуться
		{this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));}
		if (levellogic.ghostorientation()=="natural" && levellogic.statusghost(this.name)=="life") //тут наоборот
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0));
		 if (levellogic.statusghost(this.name)=="dead") //если мертв
			this.transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
		//print (levellogic.ghostorientation());

		if (levellogic.islevelstart ()) 
		{
			if (levellogic.statusghost (this.name) == "life") 
			{ //если призрак жив
				//print(agent.remainingDistance);
				if(agent.remainingDistance == 0)
				{
					Ipurp = Random.Range (0, 6);
					agent.destination = test [Random.Range(0,26)].position;
				} 
			}
				//= Goal.position; //направляем к цели - пакману 
			else 
				agent.destination = zeropos; //если он голубой или мертв, идем в стартовую локацию

			if(levellogic.statusghost(this.name)=="dead" && agent.remainingDistance==0) //если мертвый пришел в старт, то он оживает
				levellogic.riseghost(this.name);

			/*if (agent.remainingDistance < 2) 
			{ //если догнал, пока ничего... но лучше взрыв
				//Goal.position = new Vector3(99.71, 0.6, 91.6); //кидаем в исходную точку
				//ghost_transform.position= new Vector3 (91,0,107);
				//Goal.position = new Vector3(100, 0, 92); //кидаем в исходную точку
			}*/
			if (levellogic.levelnum () > Level) 
			{
				ReturnBase ();
				agent.speed += 2;
				Level = levellogic.levelnum ();
				this.transform.rotation = new Quaternion (0, 0, 0, 0); //тут будет косяк
			}

			if (levellogic.ispacmandie() && levellogic.pacmanlifenum() > 0) 
			{
				ReturnBase ();
			}

		} 
		else
			agent.destination = this.transform.position;

		if (levellogic.ispacmandie() && levellogic.pacmanlifenum() > 0) 
		{
			ReturnBase ();
		}

		if (this.transform.position.x <= (Goal.position.x + 0.5) && this.transform.position.x >= (Goal.position.x - 0.5)
		    && this.transform.position.z <= (Goal.position.z + 0.5) && this.transform.position.z >= (Goal.position.z - 0.5) 
		    && this.transform.position.y <= (Goal.position.y + 2) && this.transform.position.y >= (Goal.position.y - 2)
		    ) 
		{
			if(levellogic.ghostorientation() == "blue" && levellogic.statusghost(this.name)=="life")
				levellogic.dieghost(this.name);
			else if (levellogic.ghostorientation() == "natural" && levellogic.statusghost(this.name)=="life")
				levellogic.diepacman();
		}
					
	}
	public void ReturnBase()
	{
		this.transform.position = zeropos;
	}
}
