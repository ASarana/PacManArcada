﻿using UnityEngine;
using System.Collections;

public class Lifetext : MonoBehaviour {
	TextMesh text;
	public LevelLogic levellogic;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Life:" + levellogic.pacmanlifenum();
	
	}
}
