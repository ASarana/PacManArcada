using UnityEngine;
using System.Collections;

public class timetext : MonoBehaviour {
	TextMesh text;
	public LevelLogic levellogic;
	Time timer;
	int Level;
	bool firststart;
	Time deltatimer;
	// Use this for initialization
	void Start () {
	/*	text = GetComponent<TextMesh>();

		Level = levellogic.levelnum ();
		firststart = true;
		deltatimer=(Time)0.0;*/
	}

	// Update is called once per frame
	void Update () {
		/*if (levellogic.islevelstart () && Level == levellogic.levelnum () && firststart == true) 
		{
			firststart = false;
			timer = Time.time;
		}*/

	/*	if (levellogic.islevelstart () && (Level > levellogic.levelnum () ||  Level < levellogic.levelnum ())) 
		{
			deltatimer = Time.time;
			timer = (Time)0;
			Level = levellogic.levelnum ();

		}

		if (levellogic.islevelstart ()) 
		{
			timer = Time.time - deltatimer;
		}

		if (!levellogic.islevelstart ()) 
		{
			deltatimer = deltatimer + (Time.time - timer);
		}


		if(timer.ToString().Length==1) text.text = "000000" + levellogic.showscore().ToString();
		if(timer.ToString().Length==2) text.text = "00000" + levellogic.showscore().ToString();
		if(timer.ToString().Length==3) text.text = "0000" + levellogic.showscore().ToString();
		if(timer.ToString().Length==4) text.text = "000" + levellogic.showscore().ToString();
		if(timer.ToString().Length==5) text.text = "00" + levellogic.showscore().ToString();
		if(timer.ToString().Length==6) text.text = "0" + levellogic.showscore().ToString();
		if(timer.ToString().Length==7) text.text = levellogic.showscore().ToString();
		if (timer.ToString ().Length == 8)
			timer=(Time)0;;
		
	*/
	}
}
