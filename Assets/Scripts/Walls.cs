using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    private enum Wall {
        rightWall,
        leftWall
    }

    private Wall wall;
    private float wallSpeed;
    public float speed = 5;
    public float endPoint = 0f;


    private void Start() {
        SetWall();
        wallSpeed = ObstacleMovement.obstacleSpeed * speed / 100f;
    }

    private void FixedUpdate() {
        MoveWall(endPoint);
    }

    void SetWall() {
        if (transform.position.x > 0) {
            wall = Wall.rightWall;
        } else {
            wall = Wall.leftWall;
        }
    }

    void MoveWall(float endPoint) {
        if (wall == Wall.rightWall && transform.position.x >= endPoint) {
            transform.Translate(Vector3.left * Time.deltaTime * wallSpeed);
        } 
        else if (wall == Wall.leftWall && transform.position.x <= -endPoint) {
            transform.Translate(Vector3.right * Time.deltaTime * wallSpeed);
        }


    }
}
