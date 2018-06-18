using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    
    private int timesHit;
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    private bool isBreakable;
    public GameObject smoke;

    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        //Keep Track of Breakable Bricks
        if (isBreakable) {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnCollisionEnter2D(Collision2D collision){
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable) {
            HandleHits();
        }
    }
    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestoryed();
            PuffOfSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void PuffOfSmoke() {
        GameObject smokepuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        var smokepuffmain = smokepuff.GetComponent<ParticleSystem>().main;
        smokepuffmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites() {
        int spriteIdx = timesHit - 1;
        //Safety If we fail to find a new sprite the sprite does not change.  
        if (hitSprites[spriteIdx]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIdx];
        }
    }
    // TODO Remove this method once we can actually Win!
    void SimulateWin() {
        levelManager.LoadLevelNextLevel();
    }
}
