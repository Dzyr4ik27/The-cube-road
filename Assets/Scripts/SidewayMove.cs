using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewayMove : MonoBehaviour {

    private float groundWidth = 12f;
    public float moveSpeed;

    private float distToWall;
    public float obstacleWidth;

    private RaycastHit hit;


    private void FixedUpdate() {

        //if (transform.position.x >= endPointX) {
        //    moveSpeed = -moveSpeed;
        //} else if (transform.position.x <= -endPointX) {
        //    moveSpeed = -moveSpeed;
        //}

        MoveObstacle();
    }

    public void MoveObstacle() {
        distToWall = obstacleWidth / 2f;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, distToWall) ||
            Physics.Raycast(transform.position, Vector3.left, out hit, distToWall)) {
            moveSpeed = -moveSpeed;
        }

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }


}
