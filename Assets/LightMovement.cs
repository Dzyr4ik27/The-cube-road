using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

    public float zeroPositionZ = 0f;
    public static float lightSpeed = 17f;


    private void FixedUpdate() {
        MoveObstacle();

        if (transform.position.z <= zeroPositionZ) { /// 2f
            DeleteObstacle();
        }
    }

    void MoveObstacle() {
        transform.Translate(Vector3.back * Time.fixedDeltaTime * lightSpeed); 
    }

    public void DeleteObstacle() {
        Destroy(gameObject);
    }


    
}
