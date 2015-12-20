using UnityEngine;
using System.Collections;

public class scoretext : MonoBehaviour {
	TextMesh text;
	public LevelLogic levellogic;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if(levellogic.showscore().ToString().Length==1) text.text = "000000" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==2) text.text = "00000" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==3) text.text = "0000" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==4) text.text = "000" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==5) text.text = "00" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==6) text.text = "0" + levellogic.showscore().ToString();
		if(levellogic.showscore().ToString().Length==7) text.text = levellogic.showscore().ToString();
		if (levellogic.showscore ().ToString ().Length == 8)
			levellogic.incscore (-9999999);

	}
}
