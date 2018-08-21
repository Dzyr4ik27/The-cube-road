using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSidewayWalls : MonoBehaviour {

    public GameObject leftWall;
    public GameObject rightWall;

    public int wallCount = 10;
    private int spawnIndex;
    private int tempSpawnIndex;
    public float spawnTime;

    public float wallOffset = 30f;
    private float tempOffset;

    private int spawnCount;

    private void Start() {
        spawnCount = 0;
        spawnIndex = -1;
    }

    IEnumerator SpawnWalls() {
        tempOffset = wallOffset;

        for (int i = 0; i < wallCount; ++i) {
            SetSpawnIndex();
            SwitchPosition();
            //wallOffset += tempOffset;

            yield return new WaitForSeconds(spawnTime / ObstacleMovement.obstacleSpeed);
        }    
    }

    void SwitchPosition() {
       switch (spawnIndex) {
            case 0: {
                    leftWall.GetComponent<Walls>().endPoint = Random.Range(2, 7);
                    Instantiate(leftWall, new Vector3(-11f, 3.75f, wallOffset), Quaternion.identity);
                    break;
                }
            case 1: {
                    rightWall.GetComponent<Walls>().endPoint = Random.Range(2, 7);
                    Instantiate(rightWall, new Vector3(11f, 3.75f, wallOffset), Quaternion.identity);
                    break;
                }

        }
    }

    void SetSpawnIndex() {
        tempSpawnIndex = spawnIndex;
        spawnIndex = Random.Range(0, 2);

        if (spawnIndex == tempSpawnIndex) {
            ++spawnCount;
        } else {
            spawnCount = 0;
        }

        if (spawnCount == 2) {
            spawnCount = 0;
            SetSpawnIndex();
            return;
        }
        
    }


}
