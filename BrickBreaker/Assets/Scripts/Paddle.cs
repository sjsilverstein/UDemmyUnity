using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }


    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();

        }
        else {
            AutoPlay();
        }
        
    }
    void MoveWithMouse() {
        //Relative x position in blocks
        float mouseXPosInBlocks = Input.mousePosition.x / Screen.width * 16;
        //float mouseYPosInBlocks = Input.mousePosition.y / Screen.height * 12;
        //Vector3 X , Y , Z Coordinates
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mouseXPosInBlocks, .5f, 15.5f);
        //paddlePos.y = Mathf.Clamp(mouseYPosInBlocks, 0.195f, 2f);
        this.transform.position = paddlePos;
    }
    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, .5f, 15.5f);
        this.transform.position = paddlePos;
    }
}
