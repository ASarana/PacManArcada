using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour 
{
	public Transform Goal; //куда вигаться, сюда впихнем пакмана
	private NavMeshAgent agent; //текущий объект
	private Vector3 home;
	private Vector3 zeropos;
	public LevelLogic levellogic;
	private int Level;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
//		ghost_transform = GetComponent<Transform> ();
		home = new Vector3 (56, 0, 56);
		zeropos = this.transform.position;
		Level = levellogic.levelnum ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levellogic.islevelstart () == true) 
		{
			if (this.transform.rotation.y != 0)
				agent.destination = Goal.position; //направляем к цели - пакману 
			else 
				agent.destination = home;

			if (agent.remainingDistance < 2) 
			{ //если догнал, пока ничего... но лучше взрыв
				//Goal.position = new Vector3(99.71, 0.6, 91.6); //кидаем в исходную точку
				//ghost_transform.position= new Vector3 (91,0,107);
				//Goal.position = new Vector3(100, 0, 92); //кидаем в исходную точку
			}
			if (levellogic.levelnum () > Level) 
			{
				ReturnBase ();
				agent.speed += 2;
				Level = levellogic.levelnum ();
				this.transform.rotation = new Quaternion (0, 0, 0, 0);
			}

			if (levellogic.ispacmandie() == true && levellogic.pacmanlifenum() > 0) 
			{
				ReturnBase ();
			}

		} 
		else
			agent.destination = this.transform.position;

		if (levellogic.ispacmandie() == true && levellogic.pacmanlifenum() > 0) 
		{
			ReturnBase ();
		}

		if (this.transform.position.x <= (Goal.position.x + 0.5) && this.transform.position.x >= (Goal.position.x - 0.5)
		    && this.transform.position.z <= (Goal.position.z + 0.5) && this.transform.position.z >= (Goal.position.z - 0.5) 
		    && this.transform.position.y <= (Goal.position.y + 2) && this.transform.position.y >= (Goal.position.y - 2)
		    ) 
		{
			levellogic.diepacman();
		}
					
	}
	public void ReturnBase()
	{
		this.transform.position = zeropos;
	}
}
