using UnityEngine;
using System.Collections;

public class lifetext : MonoBehaviour {

	public LevelLogic levellogic;
	private TextMesh Text;
	// Use this for initialization
	void Start () 
	{
		Text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Text.text = "Здоровье: " + levellogic.pacmanlifenum ();
	}
}
