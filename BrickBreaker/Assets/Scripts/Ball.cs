using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    //Tracks if player has launched the ball off the paddle.
    private bool hasStarted = false;
    private AudioSource audio; 
	
    // Use this for initialization
	void Start () { 
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        //Locks Ball to paddle until mouse click
        if (!hasStarted) { 
        this.transform.position = paddle.transform.position + paddleToBallVector;
        }
        //On mouse click launches ball off paddle.
        if (Input.GetMouseButtonDown(0) && !hasStarted) {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range (0f, 0.2f));
        if (hasStarted)
        {
            audio.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
            
        }
    }
}
