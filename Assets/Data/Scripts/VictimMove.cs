using UnityEngine;
using System.Collections;

public class VictimMove : MonoBehaviour 
{

	private CharacterController victim; // Reference to the ball controller.
	public Transform victim_trans;
	public Transform hero;
	public float speedvict; 
	private Vector3 move;
	

	void Start () 
	{
		victim = GetComponent<CharacterController>();
		victim_trans = GetComponent<Transform>();

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		move =  hero.position - victim_trans.position ;
		move = move / move.magnitude;

	}
	void FixedUpdate () 
	{

		//victim.Move (move*0.5f);
		victim.Move (move*speedvict);
	}

	void OnCollisionEnter() 
	{
		Debug.Log("Hit Something"); 
		
	}

}
