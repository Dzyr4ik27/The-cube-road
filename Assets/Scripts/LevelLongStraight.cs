using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLongStraight : MonoBehaviour {

    private float spawnTime = 0.1f;
    private float randomPos;
    private float tempPosition;

    private float objectOffset;
    private float tempOffset;
    public float objectsCount = 0;

    private float yPosition;

    public GameObject obstacle;
    public bool needAirObjects;

    private void Start() {
        objectOffset = 10f;
        tempPosition = 100f;
        tempOffset = objectOffset;
        SpawnObjects();
    }

    void SpawnObjects() {
        if (needAirObjects) { yPosition = 3f; } else { yPosition = 0f; }
        for (int j = 0; j < 2; ++j ) {
            for (int i = 0; i < objectsCount; ++i) {
                SpawnOneObject();
            }
            objectOffset = tempOffset;
        }
       
    }

    void SpawnOneObject() {
        do {
            randomPos = Random.Range(-6, 6) + 0.5f;
        } while (randomPos == tempPosition);

        tempPosition = randomPos;
        Instantiate(obstacle, new Vector3(randomPos, yPosition, transform.GetChild(0).transform.position.z + objectOffset + 30f), 
            Quaternion.identity); // 30f - hui zna

        objectOffset += tempOffset;
    }
}
