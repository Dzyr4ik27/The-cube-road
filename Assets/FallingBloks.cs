using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBloks : MonoBehaviour {

    public GameObject smallBlock;
    public GameObject bigBlock;
    public Transform triggerEnd;
    public Transform playerTransform;

    private float blockOffsetZ;
    private float bigBlockOffsetZ;
    private float blockOffsetY = 20f;
    private float blockOffsetX;
    private int maxWidth = 5;

    public float smallBlockSpawnTime = 0.05f;
    public float bigBlockSpawnTime = 3f;



    public void SpawnBlocks() {  // new code
        StartCoroutine("SpawnSmallBlocks");   
        StartCoroutine("SpawnBigBlocks");
    }

    void SetOffsets() {
        blockOffsetX = Random.Range(-maxWidth, maxWidth + 1);
        blockOffsetZ = Random.Range(ObstacleMovement.obstacleSpeed * 0.8f, ObstacleMovement.obstacleSpeed * 1.5f);
        bigBlockOffsetZ = Random.Range(ObstacleMovement.obstacleSpeed, ObstacleMovement.obstacleSpeed * 1.5f);
    }

    IEnumerator SpawnSmallBlocks() {
        do {
            SetOffsets();
            Instantiate(smallBlock, new Vector3(blockOffsetX, blockOffsetY, blockOffsetZ), Quaternion.identity);

            yield return new WaitForSeconds(smallBlockSpawnTime);

        } while (triggerEnd.position.z >= blockOffsetZ);
    }


    IEnumerator SpawnBigBlocks() {
        do {
            yield return new WaitForSeconds(bigBlockSpawnTime);

            SetOffsets();
            Instantiate(bigBlock, new Vector3(blockOffsetX, blockOffsetY, bigBlockOffsetZ), Quaternion.identity);

        } while (triggerEnd.position.z >= blockOffsetZ);
    }





}
