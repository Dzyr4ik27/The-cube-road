using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBalls : MonoBehaviour {

    public GameObject ball;

    private int ballCount = 20;
    private int randomPos;
    private int tempPos;
    private float ballOffset = 5f;
    private float spawnTime;


    private void Start() {
        StartCoroutine("SpawnBalls");
    }

    IEnumerator SpawnBalls() {
        tempPos = 100;
        for (int i = 0; i < ballCount; ++i) {
            do {
                randomPos = Random.Range(-2, 4);
            } while (randomPos == tempPos);

            tempPos = randomPos;
            SpawnBall();
            ballOffset += 10f;

            spawnTime = Random.Range(0, 6) / 10f;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnBall() {

        switch (randomPos) {
            case -2: {
                    Instantiate(ball, new Vector3(-5f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
            case -1: {
                    Instantiate(ball, new Vector3(-3f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
            case -0: {
                    Instantiate(ball, new Vector3(-1f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
            case 1: {
                    Instantiate(ball, new Vector3(1f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
            case 2: {
                    Instantiate(ball, new Vector3(3f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
            case 3: {
                    Instantiate(ball, new Vector3(5f, 1.5f, transform.position.z + ballOffset), Quaternion.identity);
                    ball.transform.GetChild(0).GetComponent<SidewayMove>().moveSpeed *= -1;
                    break;
                }
        }
    }
}
