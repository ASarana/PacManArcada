using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour 
{
	public Transform Goal; //куда вигаться, сюда впихнем пакмана
	private NavMeshAgent agent; //текущий объект
	private Transform ghost_transform; //текущий объект
	private Vector3 home;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		ghost_transform = GetComponent<Transform> ();
		home = new Vector3 (56, 0, 56);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ghost_transform.transform.rotation.y != 0) {
			agent.destination = Goal.position; //направляем к цели - пакману
		} 
		else 
		{
			agent.destination = home;
		}

		if(agent.remainingDistance < 2) //если догнал, пока ничего... но лучше взрыв
		{
			//Goal.position = new Vector3(99.71, 0.6, 91.6); //кидаем в исходную точку
			//ghost_transform.position= new Vector3 (91,0,107);
			//Goal.position = new Vector3(100, 0, 92); //кидаем в исходную точку

		}
	}
}
