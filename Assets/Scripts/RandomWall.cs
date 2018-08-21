using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWall : MonoBehaviour {

    private int childIndex;
    private Transform randWallTransform;
    private float speed;


    private void Start() {
        randWallTransform = GetRandomWall();
        speed = ObstacleMovement.obstacleSpeed;
    }

    private void FixedUpdate() {
        randWallTransform.Translate(Vector3.down * Time.deltaTime * speed / 4); // / 4
        
    }

    public Transform GetRandomWall() {
        childIndex = Random.Range(0, transform.childCount - 1);
        return transform.GetChild(childIndex).transform;
    }

}
