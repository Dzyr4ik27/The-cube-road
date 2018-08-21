using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    Rigidbody rb;
    SpawnLevels2 spawnLevels2;
    public static float obstacleSpeed = 27f;    // 27f
    public float zeroPositionZ = 0f;
    private float currentLevelLength;

    public float speedBoost = 1f;
    public float levelOffset = 0f; // the offset at the beginning of the level

    private float timeToIncreaseSpeed = 5f;
    private float deltaSpeed = 0.5f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        spawnLevels2 = FindObjectOfType<SpawnLevels2>();
        currentLevelLength = spawnLevels2.CurrentLevelLength;

        StartCoroutine("ChangeSpeed");
    }

    private void FixedUpdate() {
        MoveObstacle();
        
        if (transform.position.z <= zeroPositionZ - currentLevelLength * 1.5f) { /// 2f
            DeleteObstacle();
        }


    }


    void MoveObstacle() {
        //rb.AddForce(Vector3.back * obstacleSpeed * Time.deltaTime);
        transform.Translate(Vector3.back * Time.fixedDeltaTime * obstacleSpeed * speedBoost);  // new code
    }

    public void DeleteObstacle() {
        Destroy(gameObject);
    }

    //void IncreaseSpeed() {
    //    if (Time.timeSinceLevelLoad >= timeToIncreaseSpeed) {
    //        obstacleSpeed += 5f;
    //    }
    //}

    IEnumerator ChangeSpeed() {
        yield return new WaitForSeconds(timeToIncreaseSpeed);

        ObstacleMovement.obstacleSpeed += deltaSpeed;
    }
}

