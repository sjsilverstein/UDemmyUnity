﻿using UnityEngine;
using System.Collections;

public class LossCollider : MonoBehaviour {

	private LevelManager levelManager;
		
	void OnTriggerEnter2D (Collider2D tigger){
        levelManager = GameObject.FindObjectOfType<LevelManager>();
		print("Trigger");
		levelManager.LoadLevel("Loose Screen");
	}
	void OnCollisionEnter2D(Collision2D collision){
		print("Collision");	
	}
}
