using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneObjectMovement : MonoBehaviour {

    public float zeroPositionZ = 0f;
    private float obstacleSpeed;
    public float speedBoost = 1f;


    private void FixedUpdate() {
        MoveObstacle();

        if (transform.position.z <= zeroPositionZ) { /// 2f
            DeleteObstacle();
        }
    }

    void MoveObstacle() {
        obstacleSpeed = ObstacleMovement.obstacleSpeed;
        transform.Translate(Vector3.back * Time.fixedDeltaTime * obstacleSpeed * speedBoost);  
    }

    public void DeleteObstacle() {
        Destroy(gameObject);
    }
}
