using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load request made for: "+name);
        Brick.breakableCount = 0;
        Application.LoadLevel(name);
	}
	public void QuitRequest (){
		Debug.Log("Quit Request");
		Application.Quit ();
	}
    public void LoadLevelNextLevel() {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void BrickDestoryed() {
        //If this is the last brick is destoryied then LoadNext Level
        if (Brick.breakableCount <= 0) {
            LoadLevelNextLevel();
        }
    }
}
