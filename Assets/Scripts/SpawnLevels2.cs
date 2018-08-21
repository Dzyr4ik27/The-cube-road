using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels2 : MonoBehaviour {

    public GameObject[] levelsArray;
    ObstacleMovement obstacleMovement;

	private float currentLevelLength;
    public float CurrentLevelLength { get { return currentLevelLength; } }
    private float nextLevelLength;
    private float spawnPoint;
    private int levelIndex;
    public int GetLevelIndex { get { return levelIndex; } }
    private float firstLevelSpawnPoint = 70f;


    

    private void Start() {
        SpawnLevel(firstLevelSpawnPoint);
        obstacleMovement = FindObjectOfType<ObstacleMovement>();
    }

  
    public void SpawnLevel() {

        //if (ObstacleMovement.obstacleSpeed <= 60f) { // new code
        //    ObstacleMovement.obstacleSpeed += 1f;
        //}
        

        SetRandomLevelIndex();
        nextLevelLength = GetLevelLength(levelIndex);

        if (CheckSpawnLevel() == false) {
            SpawnLevel();
            return;
        }

        SetSpawnPoint();

        Instantiate(levelsArray[levelIndex], new Vector3(0f, 0f, spawnPoint), Quaternion.identity);

        currentLevelLength = nextLevelLength;
    }

    // spawn firts level
    public void SpawnLevel(float spawn_point) {  
        SetRandomLevelIndex();
        currentLevelLength = GetLevelLength(levelIndex);

        if (currentLevelLength > 100f) {  //new code//////////////////////////////////////
            SpawnLevel(spawn_point);
            return;
        }


        Instantiate(levelsArray[levelIndex], new Vector3(0f, 0f, spawn_point), Quaternion.identity);
    }       

    bool CheckSpawnLevel() {
        if ((levelsArray[levelIndex].tag == "Level_RandomWall" && IsRandomWallActive()) || 
            (levelsArray[levelIndex].tag == "Level_SidewayWall" && IsSideWayWallActive())) {
            return false;
        }
        return true;
    }

    //void SetSpawnPoint() {
    //    obstacleMovement = levelsArray[levelIndex].GetComponent<ObstacleMovement>();
    //    spawnPoint = currentLevelLength + nextLevelLength / 2f - Mathf.Abs(obstacleMovement.zeroPositionZ) +
    //       obstacleMovement.levelOffset; // 20f - distance betwenn levels
    //}

    void SetSpawnPoint() {
        obstacleMovement = levelsArray[levelIndex].GetComponent<ObstacleMovement>();
        spawnPoint = currentLevelLength + nextLevelLength / 2f + obstacleMovement.zeroPositionZ +
           obstacleMovement.levelOffset; // 20f - distance betwenn levels
    }


    void SetRandomLevelIndex() {
        levelIndex = Random.Range(0, levelsArray.Length);
    }
    Vector3 GetLastChildPosition(int level_index) {
        return levelsArray[level_index].transform.GetChild(levelsArray[level_index].transform.childCount - 1).transform.position;
    }
    Vector3 GetChildPosition(int level_index, int child_index) {
        return levelsArray[level_index].transform.GetChild(child_index).transform.position;
    }
    float GetLevelLength(int level_index) {
        return GetLastChildPosition(level_index).z - GetChildPosition(level_index, 0).z;
    }


    //Levels check
    bool IsRandomWallActive() {
        return FindObjectsOfType<RandomWall>().Length > 0;
    }

    bool IsSideWayWallActive() {
        return FindObjectsOfType<Walls>().Length > 0;
    }


}
