using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour {

    //public GameObject[] levels;
    //public Transform playerTransform;

    //private float spawnLength = 100f; // the length from player to first child of levels
    //private float spawnPoint;
    //private float halfLevel;
    //private Transform lastObstacle;
    //private GameObject currentLevel;
    ////private int 0;
    //private int childCount; // the number of level's children

    //private void Start() {

    //    SetRandomLevel();

    //    childCount = levels[0].transform.childCount;

    //    halfLevel = (levels[0].transform.GetChild(childCount - 1).transform.position.z -
    //                    levels[0].transform.GetChild(0).transform.position.z) / 2;

    //    float firstChildPos = levels[0].transform.position.z - halfLevel;
    //    spawnPoint = spawnLength + halfLevel;

    //    Spawn(levels[0], spawnPoint);
    //}

    //private void Update() {
    //    halfLevel = (levels[0].transform.GetChild(childCount - 1).transform.position.z -
    //                    levels[0].transform.GetChild(0).transform.position.z) / 2;
    //    spawnPoint = spawnLength + halfLevel;
    //    float lastChildPosition = levels[]
    //    Debug.Log("lastChildPosition " + lastChildPosition);
    //    if (lastChildPosition <= spawnLength) {
    //        Spawn(levels[0], spawnPoint);
    //    }

    //}

    //void Spawn(GameObject level, float spawnPoint) {
    //    currentLevel = Instantiate(level, new Vector3(0f, 0f,spawnPoint), Quaternion.identity);
    //    lastObstacle = levels[0].transform.GetChild(childCount - 1);
    //    //Debug.Log("levelPosition" + levels[0].transform.position.z);

    //    SetRandomLevel();
    //}

    //void SetRandomLevel() {
    //    currentLevel = levels[0];
    //}

    //void SetSpawnPoint() {
    //    spawnPoint = playerTransform.position.z + spawnLength +
    //       (levels[0].transform.GetChild(childCount - 1).transform.position.z -
    //       levels[0].transform.GetChild(0).transform.position.z) / 2;
    //}




    public GameObject[] levelsArray;
    public Transform playerTransform;

    private float spawnPoint;
    private int levelIndex;
    private float levelLength;
    private float frontDistance = 100f; //  distance from player



    private void Start() {
        SpawnLevel();
        
    }

    private void Update() {
        //if (GetLastChildPosition().z <= 100f) {
        //    SpawnLevel();

        Debug.Log("pos1 " + GetChildPosition(0));
        Debug.Log("pos2 " + GetChildPositionNew(0));
    }

    public void SpawnLevel() {
        SetRandomLevelIndex();
        levelLength = GetLastChildPosition().z - GetChildPosition(0).z;
        SetSpawnPoint();

        Instantiate(levelsArray[levelIndex], new Vector3(0f, 0f, spawnPoint), Quaternion.identity);
        
    }

    public void SetSpawnPoint() {
        spawnPoint = playerTransform.position.z + frontDistance + levelLength / 2;
    }

    Vector3 GetLastChildPosition() {
        return levelsArray[levelIndex].transform.GetChild(levelsArray[levelIndex].transform.childCount - 1).transform.position;
    }
    Vector3 GetChildPosition(int childIndex) {
        return levelsArray[levelIndex].transform.GetChild(childIndex).transform.position;
    }

    Vector3 GetChildPositionNew(int childIndex) {
        return levelsArray[levelIndex].transform.GetChild(childIndex).position;
    }

    public void SetRandomLevelIndex() {
        levelIndex = Random.Range(0, levelsArray.Length);
    }


    
}
