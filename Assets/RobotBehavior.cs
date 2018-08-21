using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBehavior : MonoBehaviour {

    private Vector3 defaultPosition;

    public float robotSpeed = 0.125f;
    public Vector3 robotOffset;

    private Transform player;

    private void Start() {
        player = FindObjectOfType<CameraMovement>().playerTransform;
    }

    private void FixedUpdate() {
        MoveRobot();
    }

    void MoveRobot() {
        defaultPosition = player.position + robotOffset;
        transform.position = Vector3.Lerp(transform.position, defaultPosition, robotSpeed);
    }
}
