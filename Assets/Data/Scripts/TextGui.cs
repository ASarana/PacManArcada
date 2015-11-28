using UnityEngine;
using System.Collections;

public class TextGui : MonoBehaviour 
{
	public LevelLogic levellogic;
	// Use this for initialization
	private TextMesh Text;
	void Start () 
	{
		Text = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (levellogic.islevelstart () == false && levellogic.ispacmandie () == false)
			Text.text = "Паркада\nУровень" + levellogic.levelnum ();
		else if (levellogic.islevelstart () == false && levellogic.ispacmandie () == true && levellogic.pacmanlifenum () > 0)
			Text.text = "Ещё\nпопытка";
		else if (levellogic.islevelstart () == false && levellogic.ispacmandie () == true && levellogic.pacmanlifenum () <= 0)
			Text.text = "Ты мертв!";
		else
			Text.text = " ";

	}
}
