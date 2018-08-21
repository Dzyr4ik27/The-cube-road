using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    
    PlayerMovement playerMovement;
    SpawnLevels2 spawnLevels2;
    ObstacleMovement[] obstacleMovementsArray;

    Animator playerAnimator;
    Animator cameraAnimator;
    public Animator gameOverPageAnimator;

    Score score;

    private bool isEnded = false;

    public GameObject gameOverPage;
    public Text gameOverScoreText;

    public GameObject scorePage;
    //public GameObject scorePage;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        playerMovement = FindObjectOfType<PlayerMovement>();
        spawnLevels2 = FindObjectOfType<SpawnLevels2>();
        playerAnimator = playerMovement.animator;
        cameraAnimator = GetComponent<Animator>();
        score = FindObjectOfType<Score>();
    }


    private void OnEnable() {
        PlayerCollision.OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable() {
        PlayerCollision.OnPlayerDied -= OnPlayerDied;
    }

    void OnPlayerDied() {
        EndGame();
    }


    public void EndGame() {

        if (!isEnded) {

            isEnded = true;
            playerMovement.enabled = false;
            spawnLevels2.enabled = false;
            //rigidbody = kinematic;
            obstacleMovementsArray = FindObjectsOfType<ObstacleMovement>();
            for (int i = 0; i < obstacleMovementsArray.Length; i++) {
                obstacleMovementsArray[i].enabled = false;
            }

            GetComponent<CameraMovement>().enabled = false;
            playerAnimator.SetTrigger("Die");
            //cameraAnimator.SetTrigger("PlayerDied");


            score.score = score.tempScore;
            gameOverScoreText.text += score.score.ToString();
            gameOverPage.SetActive(true);
            gameOverPageAnimator.SetTrigger("PlayerDie");
            scorePage.SetActive(false);
            score.enabled = false;


            //SceneManager.LoadScene(1);
            //Invoke("RestartLevel", 3f);
            
        } else return;



    }

    public void RestartLevel() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ObstacleMovement.obstacleSpeed = 27f;
        SceneManager.LoadScene(0);
    }

    public void StartGame() {
        
    }
}