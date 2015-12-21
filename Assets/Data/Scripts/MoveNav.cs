using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour 
{
	public Transform Goal; //куда вигаться, сюда впихнем пакмана
	private NavMeshAgent agent; //текущий объект
	private Vector3 zeropos;
	public LevelLogic levellogic;
	private int Level;
	public Transform[] test = new Transform[27];

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		zeropos = this.transform.position;
		Level = levellogic.levelnum ();
		agent.destination = zeropos;
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
				if (agent.remainingDistance == 0) 
				{
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
		if (!levellogic.islevelstart ()) 
		{
			ReturnBase ();
			if (levellogic.levelnum () > Level || levellogic.levelnum () < Level) 
			{
				//agent.acceleration += 2;
				Level = levellogic.levelnum ();
			}
		//	if(this.name == "Inky") print (agent.remainingDistance);
		}
					
	}
	public void ReturnBase()
	{
		this.transform.position = zeropos;
		agent.destination = zeropos;
		this.transform.rotation = Quaternion.Euler (new Vector3 (0, 180, 0)); 
		levellogic.makeghostnatural ();
		levellogic.riseghost (this.name);

	}
}
