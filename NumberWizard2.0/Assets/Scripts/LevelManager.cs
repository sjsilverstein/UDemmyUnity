using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load request made for: "+name);
		Application.LoadLevel(name);
	}
	public void QuitRequest (){
		Debug.Log("Quit Request");
		Application.Quit ();
	}	
}
