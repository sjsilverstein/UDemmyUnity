﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;	
	int maxGuessesAllowed = 10;	
	public Text guessText; 
	void Start() {
		StartGame();
	}	
	void StartGame(){
		max = 1000;
		min = 1;
		NextGuess();	
	}
	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	public void GuessLower(){
		max = guess;
		NextGuess();
	}
	void NextGuess(){
		guess = Random.Range(min, max+1);
		guessText.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed -1;
		if (maxGuessesAllowed <= 0 ){
			//Go to player win screan
			Application.LoadLevel("Win");
		}
	}
}
