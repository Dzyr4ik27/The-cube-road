using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject block;
    private float blockOffsetZ;
    private float blockOffsetY = 20f;
    private float blockOffsetX;
    private int maxWidth = 5;
    public float spawnBlockTime;

    public float spawnLightsTime;
    public GameObject rightMoveDownLight;
    public GameObject leftMoveDownLight;
    public GameObject rightMoveUpLight;
    public GameObject leftMoveUpLight;

    private float spawnPositionZ; // light
    private Vector3 leftMoveUpLightPos = new Vector3(-5.9f, 1.5f, 75f);
    private Vector3 rightMoveUpLightPos = new Vector3(5.9f, 1.5f, 75f);
    private Vector3 leftMoveDownLightPos = new Vector3(-5.9f, 19f, 75f);
    private Vector3 rightMoveDownLightPos = new Vector3(5.9f, 19f, 75f);

    private float waitTime = 10f; // time to change light



    private void Start() {
        StartCoroutine("SpawnBlock");
        StartCoroutine("SpawnLights");
        StartCoroutine("SetSpawnTime");

        StartCoroutine("SetSpeed");

    }

    IEnumerator SpawnBlock() {
        while (true) {
            yield return new WaitForSeconds(spawnBlockTime);

            SetOffsets();
            Instantiate(block, new Vector3(blockOffsetX, blockOffsetY, blockOffsetZ), Quaternion.identity);
            
        }
    }

    void SetOffsets() {
        blockOffsetX = Random.Range(-maxWidth, maxWidth);
        blockOffsetZ = Random.Range(ObstacleMovement.obstacleSpeed, ObstacleMovement.obstacleSpeed * 1.5f);
    }


    IEnumerator SpawnLights() {
        while (true) {
            yield return new WaitForSeconds(spawnLightsTime);

            Instantiate(leftMoveUpLight, leftMoveUpLightPos, Quaternion.Euler(0,0,180));
            Instantiate(rightMoveUpLight, rightMoveUpLightPos, Quaternion.identity);
            Instantiate(leftMoveDownLight, leftMoveDownLightPos, Quaternion.Euler(0, 0, 180));
            Instantiate(rightMoveDownLight, rightMoveDownLightPos, Quaternion.identity);
        }
        
    }

    IEnumerator SetSpawnTime() {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            spawnLightsTime = Random.Range(1, 6) / 10f;
        }
    }

    IEnumerator SetSpeed() {
        while (true) {
            yield return new WaitForSeconds(waitTime);

            LightMovement.lightSpeed = Random.Range(1, 6) * 10f; 
        }
    }



}
