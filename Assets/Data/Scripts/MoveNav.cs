using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour 
{
	public Transform Goal; //куда вигаться, сюда впихнем пакмана
	private NavMeshAgent agent; //текущий объект
	private Transform ghost_transform; //текущий объект

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		ghost_transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.destination = Goal.position; //направляем к цели - пакману

		if(agent.remainingDistance < 2) //если догнал, пока ничего... но лучше взрыв
		{
			//Goal.position = new Vector3(99.71, 0.6, 91.6); //кидаем в исходную точку
			//ghost_transform.position= new Vector3 (91,0,107);
			//Goal.position = new Vector3(100, 0, 92); //кидаем в исходную точку

		}
	}
}
