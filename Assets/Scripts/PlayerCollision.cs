using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    private CameraMovement cameraMovement;


    //RandomWall
    private RandomWall[] randomWallsArray;
    private int lastWallIndex;
    private int lastArrayLength;

    private float distToGround;
    private RaycastHit hit;

    private Walls[] sidewayWallsArray;

    public GameObject train;
    private int randomPos;
    private int tempPos;
    private float trainOffset = 70f;

    public GameObject sidewayWallPlatform;

    private float tempObstacleSpeed;

    public Text gemsText;

    private void Start() {
        cameraMovement = FindObjectOfType<CameraMovement>();
        distToGround = transform.localScale.y;
    }

    private void FixedUpdate() {
        if (IsInFrontOfObstacle() || IsPressedByWalls() || IsTochedBySide()) {   
            OnPlayerDied();
        }
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "FullObstacle") {
            OnPlayerDied();
        }    
    }

    private void OnTriggerEnter(Collider other) {

        switch (other.tag) {
            //SpawnLevel
            case "BeginLevel": {
                    FindObjectOfType<SpawnLevels2>().SpawnLevel();
                    break;
                }
            //Level_RandomWall
            case "RandomWall": {
                    StartCoroutine("EnableRandomWall");
                    break;
                }
            //Level_Tunel
            case "BeginTunel": {
                    cameraMovement.cameraAnimator.SetTrigger("MoveDown");
                    break;
                }
            case "EndTunel": {
                    cameraMovement.cameraAnimator.SetTrigger("MoveUp");
                    break;
                }
            //Level_SidewayWalls
            case "BeginWall": {
                    StartCoroutine("EnableSideWayWalls");
                    break;
                }
            case "Level_Trains": {
                    SpawnTrains();
                    break;
                }
            case "Level_RandomSidewayWalls": {
                    FindObjectOfType<RandomSidewayWalls>().StartCoroutine("SpawnWalls");
                    break;
                }
            case "Level_FallingBlocks": {
                    FindObjectOfType<FallingBloks>().SpawnBlocks();
                    break;
                }
            case "ScaleBall": {
                    other.GetComponent<ObstcaleBehavior>().enabled = true;
                    break;
                }
            case "DecreaseSpeed": {
                    tempObstacleSpeed = ObstacleMovement.obstacleSpeed;
                    ObstacleMovement.obstacleSpeed = 27f;
                    break;
                }
            case "IncreaseSpeed": {
                    ObstacleMovement.obstacleSpeed = tempObstacleSpeed;
                    break;
                }
            case "EndBulletRain": {
                    FindObjectOfType<RobotBehavior>().GetComponent<Animator>().SetTrigger("GetUp");
                    FindObjectOfType<RobotBehavior>().GetComponent<OneObjectMovement>().enabled = true;
                    break;
                }
            case "BulletRain": {
                    FindObjectOfType<LevelBulletRain>().enabled = true;
                    break;
                }
            case "Gem": {
                    other.GetComponent<MeshRenderer>().enabled = false;
                    GemsBehavior.gemsCount++;

                    gemsText.text = GemsBehavior.gemsCount.ToString();
                    break;
                }
        }
    }

    int i = 1;//////
    IEnumerator EnableRandomWall() {
        randomWallsArray = FindObjectsOfType<RandomWall>();
        lastWallIndex = randomWallsArray.Length - i;
        randomWallsArray[lastWallIndex].enabled = true;

        if (i < randomWallsArray.Length) i++;
        else {

            yield return new WaitForSeconds(2f);

            i = 1;
            for (int i = 0; i < randomWallsArray.Length; i++) {
                randomWallsArray[i].enabled = false;
            }
        }
    }

    IEnumerator EnableSideWayWalls() {
        sidewayWallsArray = FindObjectsOfType<Walls>();
        foreach (Walls walls in sidewayWallsArray) {
            walls.enabled = true;
        }

        yield return new WaitForSeconds(1f);
    }
 
    bool IsInFrontOfObstacle() {
        return (Physics.Raycast(transform.position, Vector3.forward, out hit, distToGround) &&
            hit.collider.tag == "Obstacle");
    }

    bool IsPressedByWalls() {
        return (Physics.Raycast(transform.position, Vector3.left, distToGround - 0.5f) &&
            Physics.Raycast(transform.position, Vector3.right, distToGround - 0.5f));
    }

    void SpawnTrains() {
         randomPos = Random.Range(-1, 2);
         tempPos = randomPos;
        SwitchPosition();

        do {
            randomPos = Random.Range(-1, 2);
        } while (randomPos == tempPos);
        tempPos = randomPos;

        trainOffset += trainOffset;

        SwitchPosition();

        do {
            randomPos = Random.Range(-1, 2);
        } while (randomPos == tempPos);
        trainOffset += trainOffset / 2f;

        SwitchPosition();

        trainOffset /= 3f;

    }

    void SwitchPosition() {

        switch (randomPos) {
            case -1: {
                    Instantiate(train, new Vector3(-4f, 2.5f, transform.position.z + trainOffset), Quaternion.identity);
                    
                    break;
                }
            case 0: {
                    Instantiate(train, new Vector3(0f, 2.5f, transform.position.z + trainOffset), Quaternion.identity);
                   
                    break;
                }
            case 1: {
                    Instantiate(train, new Vector3(4f, 2.5f, transform.position.z + trainOffset), Quaternion.identity);
                    
                    break;
                }

        }
    }


    bool IsTochedBySide() {
        return (Physics.Raycast(transform.position, Vector3.left, out hit, distToGround) && hit.collider.tag == "SideObstacle" || 
            Physics.Raycast(transform.position, Vector3.right, out hit, distToGround) && hit.collider.tag == "SideObstacle");
    }

}
